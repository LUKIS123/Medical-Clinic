namespace MedicalClinic.Calendar.Features.CreatePatientCalendarItem.Contract;

public interface ICreatePatientCalendarItemHandler
{
    Task Handle(CreatePatientCalendarItemCommand command);
}
