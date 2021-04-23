﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dominio.Interfaces.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade, TId> where TEntidade : class where TId : struct
    {
        TEntidade Adicionar(TEntidade entidade);
        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades);
        void Remover(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        bool Existe(Func<TEntidade, bool> where);
        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);
        void Dispose();
    }
}
