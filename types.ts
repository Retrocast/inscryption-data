import {
  Ability,
  AbilityMetaCategory,
  Appearance,
  CardMetaCategory,
  CardTemple,
  GemType,
  SpecialStatIcon,
  SpecialTriggeredAbility,
  Trait,
  Tribe,
} from './enums';

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

export type CardInfo = {
  metaCategories: CardMetaCategory[];
  onePerDeck: boolean;
  temple: CardTemple;
  name: string;
  description: string;
  hideAttackAndHealth: boolean;
  appearanceBehaviours: Appearance[];
  portrait: string | null;
  holoPortrait: string | null;
  animatedPortrait: string | null;
  alternatePortrait: string | null;
  pixelPortrait: string | null;
  decals: string[];
  attack: number;
  health: number;
  bloodCost: number;
  bonesCost: number;
  energyCost: number;
  gemsCost: GemType[];
  specialStatIcon: SpecialStatIcon;
  tribes: Tribe[];
  traits: Trait[];
  specialAbilities: SpecialTriggeredAbility[];
  abilities: Ability[];
  ascensionAbilities: Ability[];
  evolution: string | null;
  defaultEvolutionName: string;
  tail: string | null;
  creatureWithin: string | null;
};
