using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.UserDefined, MaxByteSize = 8000)]
public struct StrConcat : IBinarySerialize
{
    private StringBuilder intermediateResult;

    public void Init()
    {
        this.intermediateResult = new StringBuilder();
    }

    public void Accumulate(SqlString value)
    {
        if (!value.IsNull)
        {
            this.intermediateResult.Append(value.Value).Append(", ");
        }
    }

    public void Merge(StrConcat group)
    {
        this.intermediateResult.Append(group.intermediateResult);
    }

    public SqlString Terminate()
    {
        string output = string.Empty;
        if (this.intermediateResult != null && this.intermediateResult.Length > 0)
        {
            output = this.intermediateResult.ToString(0, this.intermediateResult.Length - 2);
        }

        return new SqlString(output);
    }

    public void Read(BinaryReader r)
    {
        this.intermediateResult = new StringBuilder(r.ReadString());
    }

    public void Write(BinaryWriter w)
    {
        w.Write(this.intermediateResult.ToString());
    }
}
