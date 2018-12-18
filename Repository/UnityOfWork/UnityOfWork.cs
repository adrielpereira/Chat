using System;
using WebChatQJW.Core.Data;
using WebChatQJW.Core.Repository.Entities;
using WebChatQJW.Core.Repository.Interfaces;
using WebChatQJW.Core.Repository.UnityOfWork.Interfaces;

namespace WebChatQJW.Core.Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {

        private DataContext _contexto = null;
        private RepositoryUser _user = null;
        private RepositoryMessage _message = null;
        private RepositoryLog _log = null;

        private bool disposed = false;

        public UnityOfWork()
        {
            _contexto = new DataContext();
        }

        public IRepositoryUser RepositoryUser
        {
            get
            {
                if (_user == null)
                    _user = new RepositoryUser(_contexto);
                return _user;
            }
        }

        public IRepositoryMessage RepositoryMessage
        {
            get
            {
                if (_message == null)
                    _message = new RepositoryMessage(_contexto);
                return _message;
            }
        }

        public IRepositoryLog RepositoryLog
        {
            get
            {
                if (_log == null)
                    _log = new RepositoryLog(_contexto);
                return _log;
            }
        }

        public bool Commit()
        {
            if (_contexto.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
