﻿namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begin transaction
        /// </summary>
        /// <param name="autoDetectChange"></param>
        void BeginTransaction(bool autoDetectChange = true);

        /// <summary>
        /// Commit
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback
        /// </summary>
        void Rollback();
    }
}