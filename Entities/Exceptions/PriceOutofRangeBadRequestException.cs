namespace Entities.Exceptions
{
    public class PriceOutofRangeBadRequestException : BadRequestException
    {
        public PriceOutofRangeBadRequestException() : base("Maximum price must be less than 1000 and greater than 10!")
        {
        }
    }
}
