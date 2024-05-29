using System.Collections.Generic;

public class Objective {
    public string displayText;    
    public string requirement;

    public Objective(string displayText, string requirement)
    {
        this.displayText = displayText;
        this.requirement = requirement;
    }

    public static List<Objective> GetPermit() {
        return new List<Objective>(){
            new Objective("Print out permit application form", "application_form"),
            new Objective("Print out bank statements", "livelihood_proof"),
            new Objective("Print out enrollment certificate", "certificate_of_enrollment"),
            new Objective("Pack rental agreement", "rental_agreement"),
            new Objective("Find a biometric? picture", "biometric_photo"),
            new Objective("Get Proof Health Insurance from mail", "health_insurance_proof")
        };
    }

    public static List<Objective> GetRegistration() {
        return new List<Objective>(){
            new Objective("Print out residence registration form", "registration_form"),
            new Objective("Pack rental confirmation letter", "rental_confirmation_letter")
        };
    }
}