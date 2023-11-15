
using Microsoft.AspNetCore.Mvc.RazorPages;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;
    public class ModelForEmergency : PageModel
{
    public List<BooleanForEmergency> BooleanForEmergencyList;

    public void PopulateAssignedEmergencyTypesData(CabinetVeterinarContext context, Cabinet cabinet)
    {
        var allEmergencyTypes = context.EmergencyType;
        var cabinetEmergencyTypes = new HashSet<int>(cabinet.CabinetTypes.Select(ct => ct.EmergencyTypeId));

        BooleanForEmergencyList = new List<BooleanForEmergency>();

        foreach (var emergencyType in allEmergencyTypes)
        {
            BooleanForEmergencyList.Add(new BooleanForEmergency
            {
                EmergencyID = emergencyType.ID,
                Name = emergencyType.TypeOfUrgency,
                Assigned = cabinetEmergencyTypes.Contains(emergencyType.ID)
            });
        }
    }

    public void UpdateCabinetEmergencyTypes(CabinetVeterinarContext context, string[] selectedEmergencyTypes, Cabinet cabinetToUpdate)
    {
        if (selectedEmergencyTypes == null)
        {
            cabinetToUpdate.CabinetTypes = new List<CabinetTypes>();
            return;
        }

        var selectedEmergencyTypesHS = new HashSet<string>(selectedEmergencyTypes);
        var cabinetEmergencyTypes = new HashSet<int>(cabinetToUpdate.CabinetTypes.Select(ct => ct.EmergencyTypeId));

        foreach (var emergencyType in context.EmergencyType)
        {
            if (selectedEmergencyTypesHS.Contains(emergencyType.ID.ToString()))
            {
                if (!cabinetEmergencyTypes.Contains(emergencyType.ID))
                {
                    cabinetToUpdate.CabinetTypes.Add(new CabinetTypes
                    {
                        CabinetID = cabinetToUpdate.CabinetId,
                        EmergencyTypeId = emergencyType.ID
                    });
                }
            }
            else
            {
                if (cabinetEmergencyTypes.Contains(emergencyType.ID))
                {
                    CabinetTypes cabinetTypeToRemove = cabinetToUpdate.CabinetTypes.SingleOrDefault(ct => ct.EmergencyTypeId == emergencyType.ID);
                    context.Remove(cabinetTypeToRemove);
                }
            }
        }
    }
}
