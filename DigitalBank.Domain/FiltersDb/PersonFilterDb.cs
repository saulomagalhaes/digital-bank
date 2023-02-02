using DigitalBank.Domain.Contracts.Repositories;

namespace DigitalBank.Domain.FiltersDb;

public class PersonFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}
