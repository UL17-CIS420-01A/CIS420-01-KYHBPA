using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KYHBPA.Repository.Implementation
{
    public class DocumentRepository :BaseRepository<Document, Guid>, IDocumentRepository
    {
        public DocumentRepository(EntityDbContext context) : base(context) { }

        public override void Create(Document document)
        {
            if (document.IsNull()) throw new ArgumentException(nameof(document));
            Context.Set<Document>().Add(document);
            Context.SaveChanges();
        }

        public override Document FindById(Guid id)
        {
            return Context.Set<Document>().Where(o => !o.IsDeleted).FirstOrDefault(o => o.Id == id);
        }
        public override async Task<Document> FindByIdAsync(Guid id)
        {
            return await Task.FromResult(FindById(id));
        }

        public virtual ICollection<Document> FindDocuments()
        {
            return Context.Set<Document>().Where(o => !o.IsDeleted).ToList();
        }
        public async Task<ICollection<Document>> FindDocumentsAsync()
        {
            return await Task.FromResult(FindDocuments());
        }

        public override void Delete(Document entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.IsDeleted = true;
            entity.Deleted = DateTime.UtcNow;
            Context.Set<Document>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public override int Update(Document entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.LastModified = DateTime.UtcNow;
            return base.Update(entity);
        }

        public override async Task<int> UpdateAsync(Document entity)
        {
            if (entity.IsNull()) throw new ArgumentNullException(nameof(entity));
            entity.LastModified = DateTime.UtcNow;
            return await base.UpdateAsync(entity);
        }

        public virtual ICollection<Guid> FindDocumentIds()
        {
            return Context.Set<Document>().Where(o => !o.IsDeleted).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindDocumentIdsAsync()
        {
            return await Task.FromResult(FindDocumentIds());
        }

        public ICollection<Guid> FindDocumentListIds()
        {
            return Context.Set<Document>().Where(o => !o.IsDeleted && o.IsInGallery).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindDocumentListIdsAsync()
        {
            return await Task.FromResult(FindDocumentListIds());
        }

        public ICollection<Guid> FindDeletedDocumentIds()
        {
            return Context.Set<Document>().Where(o => o.IsDeleted).Select(o => o.Id).ToList();
        }
        public async Task<ICollection<Guid>> FindDeletedDocumentIdsAsync()
        {
            return await Task.FromResult(FindDeletedDocumentIds());
        }

        public ICollection<Document> FindDeletedDocuments()
        {
            return Context.Set<Document>().Where(o => o.IsDeleted).ToList();
        }
        public async Task<ICollection<Document>> FindDeletedDocumentssAsync()
        {
            return await Task.FromResult(FindDeletedDocuments());
        }

        public ICollection<string> FindCollectionKeys()
        {
            return Context.Set<DocumentCollection>().Select(o => o.Key).Distinct().ToList();
        }
        public async Task<ICollection<string>> FindCollectionKeysAsync()
        {
            return await Task.FromResult(FindCollectionKeys());
        }

        public ICollection<string> FindAvailableCollectionKeys()
        {
            return Context.Set<DocumentCollection>().Where(o => o.CollectionSize < o.MaximumCollectionSize).Select(o => o.Key).Distinct().ToList();
        }
        public async Task<ICollection<string>> FindAvailableCollectionKeysAsync()
        {
            return await Task.FromResult(FindAvailableCollectionKeys());
        }

        public Document FindDocumentByKey(string key)
        {
            return Context.Set<Document>()
                .SingleOrDefault(o => !o.IsDeleted &&
               o.DocumentCollectionKey.Equals(key, StringComparison.InvariantCultureIgnoreCase));
        }
        public async Task<Document> FindDocumentByKeyAsync(string key)
        {
            return await Task.FromResult(FindDocumentByKey(key));
        }

        public Guid FindDocumentIdByKey(string key)
        {
            var documentId = Context
                .Set<DocumentCollection>()
                .Include(o => o.Collection)
                .SingleOrDefault(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                .Collection.SingleOrDefault().Id;
            return documentId;
        }

        public async Task<Guid> FindDocumentIdByKeyAsync(string key)
        {
            return await Task.FromResult(FindDocumentIdByKey(key));
        }

        public DocumentCollection FindDocumentsByKey(string key)
        {
            var documents = Context
                .Set<DocumentCollection>()
                .SingleOrDefault(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            return documents;
        }
        public async Task<DocumentCollection> FindDocumentsByKeyAsync(string key)
        {
            return await Task.FromResult(FindDocumentsByKey(key));
        }

        public ICollection<Guid> FindDocumentIdsByKey(string key)
        {
            var documents = Context
                .Set<DocumentCollection>()
                .Where(c => c.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                .SelectMany(o => o.Collection.Select(c => c.Id)).ToList();
            return documents;
        }
        public async Task<ICollection<Guid>> FindDocumentIdsByKeyAsync(string key)
        {
            return await Task.FromResult(FindDocumentIdsByKey(key));
        }
    }
}