using FlameIris.Domain.IRepositories;
using FlameIris.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlameIris.Domain.Repositories
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class FlameIrisRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        protected FlameIrisDBContext _dbContext;

        /// <summary>
        /// 通过构造函数注入得到数据上下文对象实例
        /// </summary>
        /// <param name="dbContext"></param>
        public FlameIrisRepositoryBase(FlameIrisDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        /// <summary>
        /// 获取所有数据-根方法
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();

            //原
            //return GetAllIncluding();
        }

        /// <summary>
        /// 获取所有数据-拼接查询条件【暂不用】
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            //将 DbSet<T> 转为 IQueryable，支持lazy load 
            var query = Table.AsQueryable();
            //拼接查询条件
            if (propertySelectors != null && propertySelectors.Count() >= 0)
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        /// <summary>
        /// EntityState
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }

        /// <summary>
        /// 获取数据库上下文对象
        /// </summary>
        /// <returns></returns>
        public FlameIrisDBContext GetDbContext()
        {
            return _dbContext;
        }

        /// <summary>
        /// 保存数据修改 
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 保存数据修改（异步）
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


        #region 获取数据

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <summary>
        /// 获取所有数据（异步）
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        /// <summary>
        /// 获取所有数据-查询条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <summary>
        /// 获取所有数据-查询条件（异步）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// 获取首条数据-查询条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取首条数据-查询条件（异步）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 获取单条数据-查询条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        /// <summary>
        /// 获取单条数据-查询条件（异步）
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().SingleAsync(predicate);
        }

        #endregion

        #region 新增数据

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            Table.Add(entity);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        /// <summary>
        /// 新增数据-批量
        /// </summary>
        /// <param name="listEntity"></param>
        public void Insert(List<TEntity> listEntity)
        {
            Table.AddRange(listEntity);
        }

        /// <summary>
        /// 新增数据-批量（异步）
        /// </summary>
        /// <param name="listEntity"></param>
        /// <returns></returns>
        public async Task InsertAsync(List<TEntity> listEntity)
        {
            await Table.AddRangeAsync(listEntity);
        }

        #endregion

        #region 删除数据

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 更新数据批量
        /// </summary>
        /// <param name="listEntity"></param>
        public void Update(List<TEntity> listEntity)
        {
            foreach (var item in listEntity)
            {
                Update(item);
            }
        }
        #endregion

        #region 查询数量

        public int Count()
        {
            return GetAll().Count();
        }

        public async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).CountAsync();
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public async Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).LongCountAsync();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await GetAll().AnyAsync(predicate);
        }

        #endregion





    }

    /// <summary>
    /// 主键为Guid类型的仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class FlameIrisRepositoryBase<TEntity> : FlameIrisRepositoryBase<TEntity, Guid> where TEntity : Entity
    {
        public FlameIrisRepositoryBase(FlameIrisDBContext dbContext) : base(dbContext)
        {
        }
    }
}
