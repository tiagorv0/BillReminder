
namespace BillReminder.Domain.DTO;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T Data { get; }
    public IReadOnlyList<string> Errors { get; }

    private Result(bool isSuccess, T data, List<string> errors)
    {
        IsSuccess = isSuccess;
        Data = data;
        Errors = errors;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, null);
    }

    public static Result<T> Success()
    {
        return new Result<T>(true, default, null);
    }

    public static Result<T> Failure(List<string> errors)
    {
        return new Result<T>(false, default, errors);
    }

    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, default, new() { error });
    }
}
