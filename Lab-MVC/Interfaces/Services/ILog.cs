using System;

namespace Lab_MVC.Interfaces.Services
{
    public interface ILog
    {
        void Trace(string format, params object[] args);

        void Debug(string format, params object[] args);

        void Info(string format, params object[] args);

        void Warn(string format, params object[] args);

        void Error(string format, params object[] args);

        void Error(Exception ex);

        void Error(Exception ex, string format, params object[] args);

        void Fatal(Exception ex, string format, params object[] args);
    }
}