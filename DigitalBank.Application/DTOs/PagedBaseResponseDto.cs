namespace DigitalBank.Application.DTOs;

public class PagedBaseResponseDto<T>
{
    public List<T> Data { get; private set; }
    public int TotalRegisters { get; private set; }

    public PagedBaseResponseDto(int totalRegisters, List<T> data)
    {
        Data = data;
        TotalRegisters = totalRegisters;
    }

}
