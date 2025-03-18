# inscryption-data

A small package that provides basic data on [cards](https://inscryption.fandom.com/wiki/Cards) and [abilities (sigils)](https://inscryption.fandom.com/wiki/Sigils) from [Inscryption](https://inscryption.fandom.com/wiki/Inscryption).

## Example usage

```js
import { defineCard, getAbilityInfo, getCardByRawName } from 'inscryption-data';

let annoyingStoat = getCardByRawName('Stoat_Talking');
console.log(defineCard(annoyingStoat)); // A Stoat is defined as: 1 Power, 3 Health.

let magpie = getCardByRawName('Magpie');
let hoarder = getAbilityInfo(magpie.abilities[1]);
console.log(`${hoarder.name}: ${hoarder.description}`); // Hoarder: When [creature] is played, you may search your deck for any card and take it into your hand.
```
