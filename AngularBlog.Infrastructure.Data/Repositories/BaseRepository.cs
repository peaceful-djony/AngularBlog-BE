using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : IdEntity<TKey>
    {
        protected readonly PostDbContext DbContext;
        private readonly DbSet<TEntity> entitiesSet;

        protected BaseRepository(PostDbContext dbContext)
        {
            DbContext = dbContext;
            entitiesSet = DbContext.Set<TEntity>();
        }

        #region IBaseRepository

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entitiesSet.ToArrayAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            // not SingleOrDefaultAsync by performance reasons
            return await entitiesSet.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            var res = false;
            try
            {
                await entitiesSet.AddAsync(entity);
                var savedCnt = await DbContext.SaveChangesAsync();
                res = savedCnt == 1;
                if (!res)
                {
                    //TODO logger.LogWaring
                    Console.WriteLine($"Entity {entity.Id} with Type {typeof(TEntity)} was not saved to DB");
                }
            }
            catch (Exception ex)
            {
                //TODO logger.LogError($"Entity {entity.Id} with Type {TEntity} was not saved to DB");
                Console.WriteLine(ex);
            }

            return res;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var res = false;
            try
            {
                entitiesSet.Update(entity);
                var updatedCnt = await DbContext.SaveChangesAsync();
                res = updatedCnt == 1;
                if (!res)
                {
                    //TODO logger.LogWaring
                    Console.WriteLine($"Entity {entity.Id} with Type {typeof(TEntity)} was not updated to DB");
                }
            }
            catch (Exception ex)
            {
                //TODO logger.LogError($"Entity {entity.Id} with Type {TEntity} was not updated to DB");
                Console.WriteLine(ex);
            }

            return res;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var res = false;
            try
            {
                var entity = await GetAsync(id);
                if (entity == null)
                {
                    //TODO logger.LogWaring
                    Console.WriteLine($"Entity {id} with Type {typeof(TEntity)} have already deleted");
                }
                else
                {
                    DbContext.Remove(entity);
                    var deletedCnt = await DbContext.SaveChangesAsync();
                    res = deletedCnt == 1;
                    if (!res)
                    {
                        //TODO logger.LogWaring
                        Console.WriteLine($"Entity {id} with Type {typeof(TEntity)} was not deleted from DB");
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO logger.LogError($"Entity {entity.Id} with Type {TEntity} was not deleted from DB");
                Console.WriteLine(ex);
            }

            return res;
        }

        #endregion
    }
}