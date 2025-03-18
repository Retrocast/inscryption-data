import { ABILITIES } from './abilities';
import { CARDS } from './cards';
import { Ability } from './enums';
import { type AbilityInfo, type CardInfo } from './types';

export function getAbilityInfo(ability: Ability): AbilityInfo {
  return ABILITIES.find((x) => x.ability == ability) as AbilityInfo;
}

export function getAbilityByName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

export function getAbilityByRawName(name: string): AbilityInfo | undefined {
  return ABILITIES.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}

export function getCardByName(name: string): CardInfo | undefined {
  return CARDS.find((x) => x.name.toLowerCase() == name.toLowerCase());
}

export function getCardByRawName(name: string): CardInfo | undefined {
  return CARDS.find((x) => x.rawName.toLowerCase() == name.toLowerCase());
}

export function defineCard(card: CardInfo): string {
  let abilities = '';
  for (let ability of card.abilities) {
    abilities += `, ${getAbilityInfo(ability).name}`;
  }
  return `A ${card.name} is defined as: ${card.attack} Power, ${card.health} Health${abilities}.`;
}
