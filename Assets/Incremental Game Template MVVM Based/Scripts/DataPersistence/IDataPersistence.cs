using IncrementalGameTemplateMVVMBased.DataPersistence.Data;

namespace IncrementalGameTemplateMVVMBased.DataPersistence
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(ref GameData data);
    }
}