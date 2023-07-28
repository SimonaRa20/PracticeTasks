﻿using System.Linq.Expressions;

namespace MovieApp.Core.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> FindAll();

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}
