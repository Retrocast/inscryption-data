using DiskCardGame;
using System.IO;

var code = new StringBuilder();
Func<string, string> String = (x) => $"\"{x}\"";
Func<bool, string> Bool = (x) => x.ToString().ToLower();
Func<Enum, string> EnumEntry = (x) => $"{x.GetType().Name}.{x}";
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
  code.AppendLine($"    ability: Ability.{info.ability},");
  code.AppendLine($"    passive: {Bool(info.passive)},");
  code.AppendLine($"    activated: {Bool(info.activated)},");
  code.AppendLine($"    metaCategories: [{string.Join(", ", info.metaCategories.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    powerLevel: {info.powerLevel},");
  code.AppendLine($"    opponentUsable: {Bool(info.opponentUsable)},");
  code.AppendLine($"    canStack: {Bool(info.canStack)},");
  code.AppendLine($"    abilityLearnedDialogue: {String(string.Join("\\n", info.abilityLearnedDialogue.lines.Select(l => l.text)))},");
  code.AppendLine($"    name: {String(info.rulebookName)},");
  code.AppendLine($"    description: {String(info.rulebookDescription)},");
  code.AppendLine($"    rawName: {String(info.name)},");
  code.AppendLine($"  }},");
}
code.AppendLine("];");
writeAndReset("D:/abilities.ts");

code.AppendLine("import { Ability, Appearance, CardMetaCategory, CardTemple, GemType, SpecialStatIcon, SpecialTriggeredAbility, Trait, Tribe } from './enums';");
code.AppendLine("import { type CardInfo } from './types';\n");
code.AppendLine("export const CARDS: CardInfo[] = [");
foreach (var info in ScriptableObjectLoader<CardInfo>.AllData) {
  code.AppendLine($"  {{");
  code.AppendLine($"    metaCategories: [{string.Join(", ", info.metaCategories.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    onePerDeck: {Bool(info.onePerDeck)},");
  code.AppendLine($"    temple: {EnumEntry(info.temple)},");
  code.AppendLine($"    name: {String(info.displayedName)},");
  code.AppendLine($"    description: {String(info.description)},");
  code.AppendLine($"    hideAttackAndHealth: {Bool(info.hideAttackAndHealth)},");
  code.AppendLine($"    appearanceBehaviours: [{string.Join(", ", info.appearanceBehaviour.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    portrait: {info.portraitTex == null ? "null" : String(info.portraitTex.name)},");
  code.AppendLine($"    holoPortrait: {info.holoPortraitPrefab == null ? "null" : String(info.holoPortraitPrefab.name)},");
  code.AppendLine($"    animatedPortrait: {info.animatedPortrait == null ? "null" : String(info.animatedPortrait.name)},");
  code.AppendLine($"    alternatePortrait: {info.alternatePortrait == null ? "null" : String(info.alternatePortrait.name)},");
  code.AppendLine($"    pixelPortrait: {info.pixelPortrait == null ? "null" : String(info.pixelPortrait.name)},");
  code.AppendLine($"    decals: [{string.Join(", ", info.decals.Select(m => String(m.name)))}],");
  code.AppendLine($"    attack: {info.baseAttack},");
  code.AppendLine($"    health: {info.baseHealth},");
  code.AppendLine($"    bloodCost: {info.cost},");
  code.AppendLine($"    bonesCost: {info.bonesCost},");
  code.AppendLine($"    energyCost: {info.energyCost},");
  code.AppendLine($"    gemsCost: [{string.Join(", ", info.gemsCost.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    specialStatIcon: {EnumEntry(info.specialStatIcon)},");
  code.AppendLine($"    tribes: [{string.Join(", ", info.tribes.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    traits: [{string.Join(", ", info.traits.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    specialAbilities: [{string.Join(", ", info.specialAbilities.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    abilities: [{string.Join(", ", info.abilities.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    ascensionAbilities: [{string.Join(", ", info.ascensionAbilities.Select(x => EnumEntry(x)))}],");
  code.AppendLine($"    evolution: {info.evolveParams == null ? "null" : String(info.evolveParams.evolution.name)},");
  code.AppendLine($"    defaultEvolutionName: {String(info.defaultEvolutionName)},");
  code.AppendLine($"    tail: {info.tailParams == null ? "null" : String(info.tailParams.tail.name)},");
  code.AppendLine($"    creatureWithin: {info.iceCubeParams == null ? "null" : String(info.iceCubeParams.creatureWithin.name)},");
  code.AppendLine($"  }},");
}
code.AppendLine("];");
writeAndReset("D:/cards.ts");
