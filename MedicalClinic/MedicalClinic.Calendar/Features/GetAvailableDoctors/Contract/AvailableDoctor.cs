namespace MedicalClinic.Calendar.Features.GetAvailableDoctors.Contract;

public readonly record struct AvailableDoctor(
    Guid Id,
    string Name);