using DiskCardGame;
using System.IO;

var code = new StringBuilder();
Action<string> writeAndReset = (file) => {
  // Fuck \r's, adding them is a total misplay from windows devs.
  File.WriteAllText(file, $"/**\n * CODE IN THIS FILE IS AUTO-GENERATED!\n * DO NOT MAKE MANUAL CHANGES BECAUSE THEY WILL BE LOST\n*/\n\n{code.ToString()}".Replace("\r", ""));
  code = new StringBuilder();
};
Action<Type> generateEnum = (type) =>
{
  var values = Enum.GetValues(type);
  code.AppendLine($"export enum {type.Name} {{");
  foreach (var value in values)
  {
    string enumName = value.ToString();
    // Why these exist???? They are explicitly defined (by a human, not some sort of automatic thing) yet never used.
    if (enumName.StartsWith("NUM_")) continue;
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
writeAndReset("D:/enums.ts");

code.AppendLine("import { Ability, AbilityMetaCategory } from './enums';");
code.AppendLine("import { type AbilityInfo } from './types';\n");
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
code.AppendLine("];");
writeAndReset("D:/abilities.ts");
