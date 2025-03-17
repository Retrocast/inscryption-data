import { Ability, AbilityMetaCategory } from "./enums";

export type AbilityInfo = {
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
