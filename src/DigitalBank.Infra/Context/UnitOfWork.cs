﻿using DigitalBank.Domain.Repositories;

namespace DigitalBank.Infra.Context;

public sealed class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly DigitalBankContext _context;
    private bool _disposed;

    public UnitOfWork(DigitalBankContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if(!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}
