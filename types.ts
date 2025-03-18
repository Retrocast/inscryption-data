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

/**
 * Type that provides information about a single ability(sigil).
 */
export type AbilityInfo = {
  /**
   * Ability ID as Ability enum.
   */
  ability: Ability;
  /**
   * Whether ability is passive or not.
   */
  passive: boolean;
  /**
   * Whether ability is activated or not.
   * Activated abilities are displayed as buttons in GBC (Act II).
   */
  activated: boolean;
  /**
   * Meta categories ability is in.
   */
  metaCategories: AbilityMetaCategory[];
  /**
   * Ability power level.
   * @see https://inscryption.fandom.com/wiki/Sigils#Sigil_Power_Level
   */
  powerLevel: number;
  /**
   * Whether ability can be used by opponent.
   * It has couple of different interactions, but generally it is false on sigils opponent can't benefit from, such as Hoarder, Trinket Bearer or Worthy Sacrifice.
   */
  opponentUsable: boolean;
  /**
   * Whether ability will work multiple times if multiple copies are present on the same card.
   * This isn't really possible in Act I/KM, and pretty much only abilities that have this flag are abilities found on cards fused by Mycologists in GBC (Act II) - Bone Digger (Sporedigger), Mental Gemnastics (Blue Sporemage), Fecundity (Spore Mice), Sentry (Sentry Spore).
   */
  canStack: boolean;
  /**
   * Line Leshy says when ability is triggered for the first time.
   */
  abilityLearnedDialogue: string;
  /**
   * Displayed ability name.
   */
  name: string;
  /**
   * Rulebook description for this ability.
   * [creature] should be replaced replaced by actual card name (in Act II card info window) or "a card bearing this sigil" (in proper rulebook).
   */
  description: string;
  /**
   * Name of Ability enum variant, used as internal ability name in the game.
   */
  rawName: string;
};

export type CardInfo = {
  /**
   * Meta categories card is in.
   * @see https://inscryption.fandom.com/wiki/Card_Meta_Categories
   */
  metaCategories: CardMetaCategory[];
  /**
   * Whether only one copy of card should be obtainable.
   * Set to true for cards such as Ouroboros, talking cards and some random cards like Ring Worm or Long Elk.
   * While it prevents card from appearing in card choices and being copied by Goobert/Mycologists, it is still technically possible to obtain multiple copies trough other means.
   */
  onePerDeck: boolean;
  /**
   * Card temple (Nature/Beast, Undead, Tech or Wizard/Magicks)
   */
  temple: CardTemple;
  /**
   * Card name.
   */
  name: string;
  /**
   * Line Leshy says when card appears in card choice for the first time.
   */
  description: string;
  /**
   * Whether attack/health text shouldn't be rendered.
   * Used only by static glitch card.
   */
  hideAttackAndHealth: boolean;
  /**
   * Card appearance behaviors.
   */
  appearanceBehaviours: Appearance[];
  /**
   * File name for main (non-GBC/non-Act II) card's portrait.
   * It is only provided for reference, and there is no way to obtain actual image using `inscryption-data`.
   */
  portrait: string | null;
  /**
   * Prefab name for 3D hologram displayed on some Act III cards.
   * It is only provided for reference, and there is no way to obtain actual 3D model using `inscryption-data`.
   */
  holoPortrait: string | null;
  /**
   * Object name for animated portrait.
   * It is only provided for reference, and there is no way to obtain actual object using `inscryption-data`.
   */
  animatedPortrait: string | null;
  /**
   * File name for alternate card's portrait.
   * It is only provided for reference, and there is no way to obtain actual image using `inscryption-data`.
   */
  alternatePortrait: string | null;
  /**
   * File name for pixel (GBC/Act II) card's portrait.
   * It is only provided for reference, and there is no way to obtain actual image using `inscryption-data`.
   */
  pixelPortrait: string | null;
  /**
   * List of file names for card's decals.
   * It is only provided for reference, and there is no way to obtain actual images using `inscryption-data`.
   */
  decals: string[];
  /**
   * Base card's power.
   */
  attack: number;
  /**
   * Base card's health.
   */
  health: number;
  /**
   * Amount of blood required to play this card.
   */
  bloodCost: number;
  /**
   * Amount of bones required to play this card.
   */
  bonesCost: number;
  /**
   * Amount of energy required to play this card.
   */
  energyCost: number;
  /**
   * Mox types requires to play this card.
   */
  gemsCost: GemType[];
  /**
   * Special power icon (e.g. Ants or Mirror).
   */
  specialStatIcon: SpecialStatIcon;
  /**
   * List of tribes card belongs to.
   */
  tribes: Tribe[];
  /**
   * List of traits card has.
   */
  traits: Trait[];
  /**
   * List of special card behaviors card has.
   * @see https://inscryption.fandom.com/wiki/Special_Card_Behaviours
   */
  specialAbilities: SpecialTriggeredAbility[];
  /**
   * List of abilities/sigils card has.
   */
  abilities: Ability[];
  /**
   * List of abilities/sigils card has in Kaycee's Mod.
   * If list is empty, then card has the same abilities as in base game.
   */
  ascensionAbilities: Ability[];
  /**
   * Raw name of card this card will turn into with Fledgling.
   */
  evolution: string | null;
  /**
   * Custom name this card will have after evolving with Fledgling.
   */
  defaultEvolutionName: string;
  /**
   * Raw name of card that will be used as tail when this card is attacked while having Loose Tail.
   * If card doesn't have this property, a "[Card name] Tail" with default texture will be used.
   */
  tail: string | null;
  /**
   * Raw name of card this card will turn into when killed while having Frozen Away.
   * If card doesn't have this property, it will turn into Opossum by default.
   */
  creatureWithin: string | null;
  /**
   * Asset name for this card, used as internal card name in the game.
   */
  rawName: string;
};
