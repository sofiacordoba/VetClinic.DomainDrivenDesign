using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class Consultation : AggregateRoot
{
    public PatientId PatientId { get; init; }
    public Text Diagnosis { get; private set; }
    public Text Treatment { get; private set; }
    public Weight CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public DateTime ConsultationStarted { get; init; }
    public DateTime? ConsultationEnd { get; set; }
    public Consultation(PatientId patientId)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        Status = ConsultationStatus.Started;
        ConsultationStarted = DateTime.UtcNow;
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Finalized)
        {
            throw new InvalidOperationException("Consultation Finalized.");
        }
    }

    public void End()
    {
        ValidateConsultationStatus();
        if(Diagnosis == null || Treatment == null || CurrentWeight == null)
        {
            throw new InvalidOperationException("Consultation cannot be Finalized");
        }

        Status = ConsultationStatus.Finalized;
        ConsultationEnd = DateTime.UtcNow;
    }

    public void SetTreatment(Text treatment)
    {
        ValidateConsultationStatus();
        Treatment = treatment;
    }
    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }
    public void SetWeight(Weight weight)
    {
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }

    public enum ConsultationStatus
    {
        Started,
        Finalized
    }
}
