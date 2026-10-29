public static class CapturePortalFactory
{
    public static CapturePortal Create(CapturePortalData data) => new CapturePortal(data);
    //public static CapturePortal CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.CapturePortalData.Get(id));
}
