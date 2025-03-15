using DiskCardGame;
using System.IO;

var code = new StringBuilder();
Action<Type> generateEnum = (type) =>
{
    var values = Enum.GetValues(type);
    code.AppendLine($"export enum {type.Name} {{");
    foreach (var value in values)
    {
        string enumName = value.ToString();
        if (enumName.StartsWith("NUM_")) continue; // Why these exist???? They are explicitly defined (by a human, not some sort of automatic thing) yet never used.
        code.AppendLine($"  {enumName} = {Convert.ToInt32(value)},");
    }

    code.AppendLine("}\n");
};

generateEnum(typeof(Ability));
generateEnum(typeof(AbilityMetaCategory));
generateEnum(typeof(CardAppearanceBehaviour.Appearance));
generateEnum(typeof(CardMetaCategory));
generateEnum(typeof(CardTemple));
generateEnum(typeof(GemType));
generateEnum(typeof(SpecialStatIcon));
generateEnum(typeof(SpecialTriggeredAbility));
generateEnum(typeof(Trait));
generateEnum(typeof(Tribe));

File.WriteAllText("index.ts", code.ToString());
