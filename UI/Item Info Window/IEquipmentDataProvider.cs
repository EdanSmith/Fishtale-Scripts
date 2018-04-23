public struct EquipmentData
{
    public string label;
    public string _value;
    public int _starAmount;
}

public interface IEquipmentDataProvider {

    EquipmentData[] GetEquipmentData();

}
