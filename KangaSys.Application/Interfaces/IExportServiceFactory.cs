// <copyright file="IExportServiceFactory.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Interfaces
{
    public interface IExportServiceFactory
    {
        IExportService GetService(string format);
    }
}
