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

## Building

While there is no reason to "build" it yourself, you can still do so with [generator.cs](generator.cs).
You need to inject this script into PC build of Inscryption by using a mod or debugger.
By default it writes scripts to the `D:` Windows drive (in my case I just symlinked `D:` to this directory in Wine).
If you're running in environment that supports `.ts` files directly (e.g. [Bun](https://bun.sh)), you're pretty much good to go.
But if you need JS output, just install TypeScript and run `tsc` in this directory, it will transpile all the scripts and write output to [dist](dist/) directory, along with type definitions and sourcemaps.
