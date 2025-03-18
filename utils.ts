import { ABILITIES } from './abilities';
import { CARDS } from './cards';
import { Ability } from './enums';
import { type AbilityInfo, type CardInfo } from './types';

/**
 * Returns AbilityInfo for variant of Ability enum.
 * @param ability Ability enum variant
 * @returns AbilityInfo for this ability
 */
export function getAbilityInfo(ability: Ability): AbilityInfo {
  return ABILITIES.find((x) => x.ability == ability) as AbilityInfo;
}

/**
 * Tries to find ability by in-game name.
 * @param name case-insensitive ability name
 * @returns AbilityInfo if it was found, undefined otherwise
 */
export function getAbilityByName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

/**
 * Tries to find ability by raw name.
 * @param name case-insensitive ability raw name
 * @returns AbilityInfo if it was found, undefined otherwise
 */
export function getAbilityByRawName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}

/**
 * Tries to find card by in-game name.
 * @param name case-insensitive card name
 * @returns CardInfo if it was found, undefined otherwise
 */
export function getCardByName(name: string): CardInfo | undefined {
  return CARDS.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

/**
 * Tries to find card by raw name.
 * @param name case-insensitive card raw name
 * @returns CardInfo if it was found, undefined otherwise
 */
export function getCardByRawName(name: string): CardInfo | undefined {
  return CARDS.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}

/**
 * Defines a card similarly to the rulebook, e.g. "A [name] is defined as: [x] Power, [y] Health[comma-separated abilities?].".
 * @param card the card itself
 * @returns definition string
 */
export function defineCard(card: CardInfo): string {
  let abilities = '';
  for (let ability of card.abilities) {
    abilities += `, ${getAbilityInfo(ability).name}`;
  }
  return `A ${card.name} is defined as: ${card.attack} Power, ${card.health} Health${abilities}.`;
}
