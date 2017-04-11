[assembly: EleWise.ELMA.Modules.Attributes.AssemblyModule(SerialNumber.__ModuleInfo.UID_S)]

[assembly: EleWise.ELMA.Modules.Attributes.Module(SerialNumber.__ModuleInfo.ModuleId, SerialNumber.__ModuleInfo.UID_S)]
[assembly: EleWise.ELMA.Modules.Attributes.ModuleTitle("SerialNumber")]

namespace SerialNumber
{

    public static class __ModuleInfo
    {
        public const string ModuleId = "SerialNumber";

        public const string UID_S = "6d65cf76-4683-4acd-b9c4-0a00913986d9";

        public static readonly System.Guid UID = new System.Guid(UID_S);

        public static string LocalizedName = EleWise.ELMA.SR.T("SerialNumber");
    }

}