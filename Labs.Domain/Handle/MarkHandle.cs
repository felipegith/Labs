using Labs.Domain.Comand;
using Labs.Domain.Comand.Utils;
using Labs.Domain.Entities;
using Labs.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Labs.Domain.Handle
{
    public class MarkHandle : IRequestHandler<AddNewMarkComand, ComandResponse>,
                              IRequestHandler<FindAllMarkEmployerComand, ComandResponse>,
                              IRequestHandler<FindAllMarkEmployeComand, ComandResponse>
                              
    {
        private readonly IMarkRepository _markRepository;
        private readonly IMemoryCache _cache;
        private const string KEY = "Cache";
        public MarkHandle(IMarkRepository markRepository, IMemoryCache cache)
        {
            _markRepository = markRepository;
            _cache = cache;
        }

        public async Task<ComandResponse> Handle(AddNewMarkComand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();

            if (!validationResult.IsValid)
                return new ComandResponse(false, "Erro ao criar a marcação", HttpStatusCode.BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));

            var addNewMark = new Mark(request.EmployeId, request.EmployerId, request.IncludedAt);

            var repository = await _markRepository.CreateAsync(addNewMark, cancellationToken);


            if (repository is null)
                return new ComandResponse(false, "Erro ao salvar a marcação", HttpStatusCode.InternalServerError);

            return new ComandResponse(true, "Marcação realizada com sucesso", HttpStatusCode.Created, addNewMark);

        }

        public async Task<ComandResponse> Handle(FindAllMarkEmployerComand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();

            if (!validationResult.IsValid)
                return new ComandResponse(false, "Erro ao buscar uma marcação", HttpStatusCode.BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));

            if (_cache.TryGetValue(KEY, out IEnumerable<Mark> marksCache))
                return new ComandResponse(true, "Busca da marcação realizada com sucesso", HttpStatusCode.OK, marksCache);

            var findAllMarking = await _markRepository.FindAllEmployerAsync(request.EmployerId, cancellationToken);

            if (findAllMarking is null)
                return new ComandResponse(false, "Erro ao buscar uma marcação", HttpStatusCode.NotFound);

            var memoryCacheConfiguration = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            _cache.Set(KEY, findAllMarking, memoryCacheConfiguration);
            return new ComandResponse(true, "Busca da marcação realizada com sucesso", HttpStatusCode.OK, findAllMarking);
        }

        public async Task<ComandResponse> Handle(FindAllMarkEmployeComand request, CancellationToken cancellationToken)
        {
            var validationResult = request.Validate();

            if (!validationResult.IsValid)
                return new ComandResponse(false, "Erro ao buscar uma marcação", HttpStatusCode.BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));

            if (_cache.TryGetValue(KEY, out IEnumerable<Mark> marksCache))
                return new ComandResponse(true, "Busca da marcação realizada com sucesso", HttpStatusCode.OK, marksCache);

            var findAllEmployeMark = await _markRepository.FindAllEmployeMarkAsync(request.EmployeId, cancellationToken);

            if (findAllEmployeMark is null)
                return new ComandResponse(false, "Erro ao buscar uma marcação", HttpStatusCode.NotFound);

            var memoryCacheConfiguration = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            _cache.Set(KEY, findAllEmployeMark, memoryCacheConfiguration);
            return new ComandResponse(true, "Busca da marcação realizada com sucesso", HttpStatusCode.OK, findAllEmployeMark);
        }
    }
}
