import { ABILITIES } from "./abilities";
import { Ability } from "./enums";
import { AbilityInfo } from "./types";

export function getAbilityInfo(ability: Ability): AbilityInfo {
  return ABILITIES.find((x) => x.ability == ability) as AbilityInfo;
}

export function getAbilityByName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

export function getAbilityByRawName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}
