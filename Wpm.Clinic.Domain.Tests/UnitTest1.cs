using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Consultation_should_be_initialized()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.True(consultation.Status == Consultation.ConsultationStatus.Started);
        }

        [Fact]
        public void Consultation_should_not_have_finalization_date()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.Null(consultation.ConsultationEnd);
        }

        [Fact]
        public void Consultation_should_not_finalize_with_missing_data()
        {
            var consultation = new Consultation(Guid.NewGuid());
            Assert.True(consultation.Status != Consultation.ConsultationStatus.Finalized);
            Assert.Throws<InvalidOperationException>(consultation.End);
        }

        [Fact]
        public void Consultation_should_finalize_with_data_completed()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("treatment");
            consultation.SetDiagnosis("diagnosis");
            consultation.SetWeight(1);
            consultation.End();
            Assert.True(consultation.Status == Consultation.ConsultationStatus.Finalized);
        }

        [Fact]
        public void Consultation_should_not_allow_to_change_weight_when_finalized()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("treatment");
            consultation.SetDiagnosis("diagnosis");
            consultation.SetWeight(1);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() =>  consultation.SetWeight(10));
        }

        [Fact]
        public void Consultation_should_not_allow_to_change_diagnosis_when_finalized()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("treatment");
            consultation.SetDiagnosis("diagnosis");
            consultation.SetWeight(1);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() => consultation.SetDiagnosis("new diagnosis"));
        }

        [Fact]
        public void Consultation_should_not_allow_to_change_treatment_when_finalized()
        {
            var consultation = new Consultation(Guid.NewGuid());
            consultation.SetTreatment("treatment");
            consultation.SetDiagnosis("diagnosis");
            consultation.SetWeight(1);
            consultation.End();

            Assert.Throws<InvalidOperationException>(() => consultation.SetTreatment("new treatment"));
        }

        [Fact]
        public void Consultation_add_drug()
        {
            var drugId = new DrugId(Guid.NewGuid());
            var consultation = new Consultation(Guid.NewGuid());
            consultation.AdministrerDrug(drugId, new Dose(1, UnitOfMeasure.tablet));

            Assert.True(consultation.AdministeredDrugs.Count() == 1);
            Assert.True(consultation.AdministeredDrugs.First().DrugId == drugId);
        }

        [Fact]
        public void Consultation_add_vital_signals_readings()
        {
            var consultation = new Consultation(Guid.NewGuid());
            IEnumerable<VitalSigns> vitalSigns = [new VitalSigns (10.1m, 20, 30 )];
            consultation.RegisterVitalSigns(vitalSigns);

            Assert.True(consultation.VitalSignsReadings.Count() == 1);
            Assert.True(consultation.VitalSignsReadings.First() == vitalSigns.First());
        }
    }
}