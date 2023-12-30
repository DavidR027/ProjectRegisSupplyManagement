﻿using Client.ViewModels;

namespace Client.Repositories
{
    public interface IGeneralRepository<T, X>
        where T : class
    {
        Task<ResponseListVM<T>> Get();
        Task<ResponseViewModel<T>> Get(X id);
        Task<ResponseMessageVM> Post(T entity);
        Task<ResponseMessageVM> Put(T entity);
        Task<ResponseMessageVM> Delete(X id);
    }
}
