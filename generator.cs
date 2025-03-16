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

code.AppendLine(@"export type AbilityInfo = {
  ability: Ability;
  passive: boolean;
  activated: boolean;
  metaCategories: AbilityMetaCategory[];
  powerLevel: number;
  opponentUsable: boolean;
  canStack: boolean;
  abilityLearnedDialogue: string;
  name: string;
  description: string;
  rawName: string;
};
");
code.AppendLine("export const ABILITIES: AbilityInfo[] = [");
foreach (var info in ScriptableObjectLoader<AbilityInfo>.AllData) {
  code.AppendLine($"  {{");
  code.AppendLine($"    ability: Ability.{info.ability.ToString()},");
  code.AppendLine($"    passive: {info.passive.ToString().ToLower()},");
  code.AppendLine($"    activated: {info.activated.ToString().ToLower()},");
  code.AppendLine($"    metaCategories: [{string.Join(", ", info.metaCategories.Select(m => $"AbilityMetaCategory.{m}"))}],");
  code.AppendLine($"    powerLevel: {info.powerLevel},");
  code.AppendLine($"    opponentUsable: {info.opponentUsable.ToString().ToLower()},");
  code.AppendLine($"    canStack: {info.canStack.ToString().ToLower()},");
  code.AppendLine($"    abilityLearnedDialogue: \"{string.Join(", ", info.abilityLearnedDialogue.lines.Select(l => l.text))}\",");
  code.AppendLine($"    name: \"{info.rulebookName}\",");
  code.AppendLine($"    description: \"{info.rulebookDescription}\",");
  code.AppendLine($"    rawName: \"{info.name}\",");
  code.AppendLine($"  }},");
}
code.AppendLine("];\n");
code.AppendLine(@"export function getAbilityInfo(ability: Ability): AbilityInfo {
  return ABILITIES.find((x) => x.ability == ability) as AbilityInfo;
}

export function getAbilityByName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

export function getAbilityByRawName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}");

File.WriteAllText("index.ts", code.ToString());
