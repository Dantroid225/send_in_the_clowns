# WEAPON_SYSTEM.md — Jokes & Gags (Auto-Attack Weapons)
# Game: Send in the Clowns | Folder codename: clowns
# Date: 2026-06-30 (rev 1 — EXPLORATORY DESIGN-AHEAD, not locked)
# Authored by: game_designer_agent (combat-model scope)
# Parent docs: MIRTH_METER_SPEC.md, ENEMY_MECHANICS.md, HUMOR_SYSTEM.md,
#              PILLARS.md, PROJECT_SUMMARY.md
#
# ┌──────────────────────────────────────────────────────────────────────────┐
# │ SCOPE BANNER — READ FIRST.                                                │
# │ A pick-up "weapon" with RANDOMIZED rolls IS the Gunfire-Reborn layer,     │
# │ which is CUT-LIST #5: BACKLOG, "must not leak into Phase 0."              │
# │ This document is DESIGNED-AHEAD on paper, exactly as HUMOR_SYSTEM.md      │
# │ designs its Layers A–E. NONE of it is built until the Phase 0 toy proves  │
# │ "the read is fun." It is here so the system is coherent when it earns its │
# │ turn — not so it gets built now.                                          │
# └──────────────────────────────────────────────────────────────────────────┘
#
# DOCTRINE NOTES (inherited, non-negotiable):
#  - Performance Model: a "weapon" is NOT written joke text. It is a reusable
#    PERFORMANCE SIGNATURE (cadence + animation beat + action/prop + VFX/SFX).
#    No real/written/scripted comedy, ever — not even as a roll name shown to
#    the player as a punchline.
#  - Pillar 2 guardrail (§4): the randomizer may NEVER produce a weapon that is
#    Strong against everything. Element rolls are constrained to preserve the read.

---

## 0. The core idea, in one frame

Your **auto-attack** (MIRTH_METER §2: the always-available baseline gag) is a
*slot*. You pick up **weapons** that swap what fires from that slot — each a
**joke/gag archetype** with its own range, cadence, and firing feel, carrying a
**humor type** (its "element," which drives the read) and a set of rolled
**attributes** (its "inscriptions"). Gunfire Reborn's gun, mapped to comedy.

```
Gunfire Reborn          →   Send in the Clowns
─────────────────────────────────────────────────────────
Gun TYPE (sniper/SMG)   →   ARCHETYPE      (one-liner, pratfall, …)  = the form/feel
Elemental affix         →   HUMOR TYPE     (Wit/Slapstick/Heart/…)   = the READ element
Inscriptions/rarity     →   ATTRIBUTES     (rolled modifiers)        = read-neutral stat tweaks
Weapon vs Skill         →   Weapon (auto)  vs  Ability "bits" (CD)    = this doc owns the former
```

Three independent identity layers, which is what gives loot depth **without**
breaking the read:

1. **CATEGORY / ARCHETYPE** — what it *is* and how it *fires* (§2–3).
2. **HUMOR TYPE** — what it counts as for `GetAffinity` (§4). The read element.
3. **ATTRIBUTES** — rolled modifiers that tune numbers/behavior (§5). The loot.

---

## 1. The two categories map onto the Register axis

The split you named — **Gags (physical)** vs **Jokes (non-physical)** — is not
arbitrary: it *is* the Register axis from HUMOR_SYSTEM (Head ↔ Body). That makes
the category meaningful instead of cosmetic.

| Category | Register pole | Form factor tendency | Natural humor types | Performance feel |
|---|---|---|---|---|
| **GAGS** (physical) | **Body** | Close / AoE / visceral / spatial | Slapstick core; splashes to Dark (gross-out), Heart (endearing stumble), Absurdism (wrong-prop) | Wind-up → big telegraphed action → recoil |
| **JOKES** (non-physical) | **Head** | Ranged / precise / single-target / timing | Wit core; splashes to Dark (gallows deadpan), Heart (wry aside), Absurdism (clever nonsense) | Stillness → held beat → dry tag |

**Key nuance:** category and humor type are *correlated, not identical.* Most gags
are Slapstick and most jokes are Wit — but a **Heart gag** (a wilted-bouquet bit)
and a **Dark joke** (a gallows one-liner) exist and are interesting precisely
because they cross the grain. Category fixes the **form** (melee/ranged,
physical/verbal performance); humor type fixes the **read element**. A player
reads *both*: "it's a shotgun-shaped thing (gag) and it reads as Slapstick."

---

## 2. The archetype roster (the "gun types")

Each archetype is a **firing profile** + a **default performance signature**
pointer (HUMOR_SYSTEM §6) + an **enemy-meter interaction**. Humor type is rolled
on top (§4); the archetype's *default* type is its center of gravity, not a lock.

Legend — meter interaction: **M**=mirth fill · **A**=attention-break ·
**Arm**=armor-crack · **risk**=bomb/heckle exposure.

### GAGS — physical, Body-leaning

| Archetype | Weapon analog | Firing profile | Default type | Meter interaction | MVP-slice? |
|---|---|---|---|---|---|
| **Pratfall / Pie** | Shotgun | Short range, wide cone, big close burst | Slapstick | **A↑↑** (loud = breaks attention fast), M burst, falls off at range | ★ candidate |
| **Knockabout** | SMG / auto | Rapid low-value hits, high fire rate | Slapstick | **M sustain** (beats decay), weak vs Arm | ★ candidate |
| **Seltzer / Prop Spray** | Cone / "flamethrower" | Continuous arc, multi-target | Slapstick/Absurdism | Crowd work (multi-M), Favor-friendly in waves | backlog |
| **Banana-Peel / Trap** | Mine / deployable | Place a gag that triggers on enemy movement | Slapstick | Zoning; **A** on trigger | backlog |
| **Gross-Out / Shock** | Grenade (high-risk) | Big AoE burst | Dark/Slapstick | **M big** but **risk↑↑** — bombs hard on wrong crowd (the "cancelled" seed) | backlog |
| **Sad-Sack / Wilting-Flower** | Support tool | Slow, earnest physical bit | **Heart** | **Arm-crack** (lowers emotional armor), opens enemies for the team | backlog (needs Armor) |
| **Absurd Prop / Wrong-Object** | Wildcard | Pulls a random prop → random effect | Absurdism | High-variance M (the "lolz" seed) | backlog |

### JOKES — non-physical, Head-leaning

| Archetype | Weapon analog | Firing profile | Default type | Meter interaction | MVP-slice? |
|---|---|---|---|---|---|
| **One-Liner** | Sniper | Long cooldown, high single-burst, long range, pinpoint | Wit | **M burst** — ideal to slam an *exposed* mirth window; poor sustain/opener | ★ candidate |
| **Dry Quip / Deadpan** | Pistol / sidearm | Medium range, low CD, modest reliable fill | Wit/Dark | The "never feels bad" baseline; weak A | ★ candidate (the safe default) |
| **Callback** | DoT / charge | Marks a target; later jokes detonate / tick mirth-over-time | Wit/Absurdism | **M-over-time**, combo seed (Layer B) | backlog |
| **Rant / Tirade** | Beam / channel | Channelled continuous fill, ramps the longer held; roots you | Wit/Dark | **Holds A open** (continuous engagement), but interruptible by heckles | backlog |
| **Observational** | Homing / lock-on | Auto-targets the most receptive enemy (best matchup) | Heart/Wit | Teaches affinity by seeking favorable reads; reliable not bursty | backlog |
| **Shaggy-Dog** | Charge-up nuke | Long wind-up; uninterrupted = huge (near-fill / Arm-shatter); interrupted = fizzle/bomb | Absurdism/Wit | **M huge or 0** — protect-the-performer co-op beat | backlog |

> **Roster discipline:** 13 archetypes is the *design space*, not the build list.
> If/when this layer is greenlit post-toy, start with the **★ four** (Pratfall,
> Knockabout, One-Liner, Dry Quip) — they cover the two axes that matter at first
> contact: **burst vs sustain** and **opener vs payoff** (see §6). Everything else
> is sequenced behind playtest evidence. Siblings merge; don't ship two SMGs.

---

## 3. Why each archetype's *function* matches its *comedy* (the thematic contract)

This is the bit you flagged — functionality must be thematic to the joke/gag, the
way a one-liner naturally reads as a sniper. The pattern that makes this
*systematic* rather than ad-hoc:

- **Comedic delivery shape → firing shape.** A one-liner is *one perfectly-timed
  shot* → sniper (long "reload," huge single hit, demands the right moment). A
  knockabout is *relentless escalating physical business* → full-auto. A shaggy-dog
  story is *all build, one payoff, ruined if interrupted* → channelled nuke. The
  comedy's **timing structure** literally specifies the weapon's cadence.
- **Comedic risk → mechanical variance.** Shock/gross-out comedy *can bomb
  catastrophically* → grenade with high bomb-risk and the "cancelled" exposure.
  Dry deadpan *rarely kills but rarely dies* → reliable low-variance sidearm. The
  comedy's **risk profile** specifies the weapon's variance.
- **Comedic register → range & physicality.** Head/verbal comedy reads at a
  *distance* and needs *precision* → ranged/single-target jokes. Body/physical
  comedy needs *proximity and impact* → close/AoE gags. The **register** specifies
  range and form.

So a designer adding a new archetype doesn't guess: they ask *what is this joke's
timing, risk, and register?* and the weapon profile falls out. That keeps the
roster authorable and on-theme as it grows.

---

## 4. Humor type = the "element" (and the Pillar-2 guardrail)

Every weapon counts as exactly **one of the five wheel types** (HUMOR_SYSTEM §1)
for the read. This is the affinity element `GetAffinity` consumes. Your example
attributes are mostly *types in disguise* — here's the mapping so they stop being
ambiguous:

| Your seed word | Wheel type it sets |
|---|---|
| dry | **Wit** |
| low-brow | **Slapstick** |
| dark | **Dark** |
| surreal / random / "lolz" | **Absurdism** |
| earnest / heartfelt / self-deprecating | **Heart** |

### THE GUARDRAIL (load-bearing on Pillar 2)

> **The element roll is constrained to exactly one wheel type, which therefore
> ALWAYS has at least one Weak matchup (HUMOR_SYSTEM §5). The randomizer may never
> produce a "Strong-vs-everything" weapon.** Loot can make a weapon *bigger*,
> *faster*, *weirder* — never *universally correct.* The moment a rolled weapon
> wins every matchup, the read has collapsed into a damage race and the toy's
> whole premise is dead. This is the one inviolable rule of the roll system.

**Splash (backlog-within-backlog):** a weapon may roll a *core* + an *adjacent*
type (HUMOR_SYSTEM §3 splash edges) — e.g. a "surreal pun" One-Liner counts full
as Wit, partial as Absurdism. Adds depth; gated until the flat single-type version
is proven.

---

## 5. Attributes = inscriptions (the read-NEUTRAL roll layer)

Separate the read-relevant element (§4) from the free-rolling loot, or you can't
balance either. Attributes are **modifiers that tweak numbers/behavior without
touching affinity.** This is where Gunfire-style "one more roll" hunger lives.

| Attribute family | Example rolls | Tunes |
|---|---|---|
| **Output** | +burst fill · +fire rate · +sustain | Mirth throughput |
| **Tempo** | −cooldown · faster "reload" · longer channel | Rhythm |
| **Reach** | +range · wider cone · ricochet to a 2nd heckler | Spacing |
| **Meter-spec** | +attention-break · +armor-crack · "primes on hit" (callback synergy) | Interaction with ENEMY_MECHANICS bars |
| **Risk** | bigger payoff **but** higher bomb-chance · "louder bomb" | Variance band |
| **Co-op** | "shares its setup with allies" · "revive bonus on Heart bits" | Fellowship (Layer C) |

**Rarity** = how many/what tier of inscriptions roll, exactly like Gunfire. A
legendary One-Liner isn't *Strong against more things* (that's forbidden, §4) —
it's a One-Liner with three juicy inscriptions (−CD, +range, ricochet).

**The split restated:** **element = the read (constrained, protects Pillar 2);
inscriptions = the loot (free, drives the hunt).** Never let an inscription grant
"Strong vs all." That single rule is what lets the system be both *lootable* and
*read-honest.*

---

## 6. How ENEMY_MECHANICS drives weapon design (you asked for this thread)

Weapons are designed **against the crowd meters**, which is what stops them being
generic damage and makes the loadout an extension of the read:

- **Attention (shield) → the opener/payoff rhythm.** Loud physical gags
  (Pratfall = shotgun) **break attention fast**; precise jokes (One-Liner = sniper)
  are weak openers but devastating into an *exposed* mirth window. The intended
  skill loop: **crack the room with a gag → slam it with a joke.** That two-tool
  rhythm is *created by* the Attention bar and *expressed by* the weapon roster —
  neither makes sense without the other.
- **Emotional Armor → register-locked tools.** Because a weapon carries a register
  (§4), a Walled enemy *demands* the keyed type — a Heart **Sad-Sack** gag to crack
  a grieving wall, a Dark tool for an edgy ward. This is why the random *element*
  matters and why a **troupe wants wheel coverage** (co-op, HUMOR_SYSTEM Layer C):
  no single rolled weapon answers every Walled crowd.
- **Mirth decay → burst vs sustain.** Sustain weapons (Knockabout SMG, Rant beam)
  beat decay and *hold* a room; burst weapons (One-Liner) can't sustain alone. The
  decay knob (MIRTH_METER §3.3) is what makes "carry one of each" a real decision.
- **Enemy offense → interruptibility as a weapon stat.** Channelled weapons (Rant,
  Shaggy-Dog) are **interruptible by heckles** (ENEMY_MECHANICS §4.1) — high payoff,
  high exposure, wants a teammate to cover. Mobile gags trade payoff for safety. The
  reverse meter turns "channel vs instant" into a live tradeoff.

**Design rule going forward:** every new weapon must answer *which crowd meter is
this good/bad against, and what does it want a teammate to do?* A weapon that only
fills mirth and ignores the other bars is a damage-race weapon — reject it.

---

## 7. Performance Model compliance (no written jokes — restated, because loot tempts it)

A "weapon" never displays a written punchline. It is a **performance-signature
loadout**:

- **Archetype** selects the **firing animation/feel** (the wind-up-WHACK of a
  pratfall, the still-beat-tag of a one-liner).
- **Humor type** selects which **§6 performance signature** plays (cadence +
  animation beat + action/prop + VFX/SFX) — so a Dark One-Liner *sounds and moves*
  Dark, a Wit One-Liner Wit, same firing shape.
- **Land/bomb feedback** is the §6 pop / fizzle — text-free, per Pillar 3.

Roll *names* (if surfaced to the player at all) describe **mechanics or register**
("Dry · Long-Reach · Ricochet"), never a joke. **Routing:** archetype firing
animations → animation; type signatures → narrative_agent (bark-cadence/performance
beats, already its retasked job) + audio. If any weapon proposal needs a writer to
author a punchline, it has violated the content model — reject and redirect to
signature design.

---

## 8. Recommended build sequence (IF/WHEN greenlit post-toy)

Mirrors HUMOR_SYSTEM §9 — data before mechanics, vertical slice before breadth,
gated milestones. **GATE 0 = Phase 0 toy passes "is the read fun?" Nothing below
starts before that.**

| WP | Focus | Exit gate |
|---|---|---|
| **WP-W0** | Weapon = SO data: {category, archetype, type, inscriptions[]} on the existing auto-attack slot | Swapping a weapon changes firing feel + read element; no written text anywhere |
| **WP-W1** | The ★ four archetypes (Pratfall, Knockabout, One-Liner, Dry Quip), single-type elements, 2 inscriptions | A 1-enemy fight where "open with gag, finish with joke" beats spamming one tool |
| **WP-W2** | Inscription roll + rarity; Pillar-2 guardrail enforced in data (no Strong-vs-all reachable) | A non-degenerate roll table; no roll wins every matchup |
| **GATE-W** | **Playtest: does swapping weapons add fun ON TOP of the proven read?** | Binary. PASS → breadth. FAIL → weapons are decoration, cut back |
| **WP-W3** | Breadth: remaining archetypes, register-locked (Heart/Dark) tools vs Walled enemies | Each new weapon answers a crowd-meter question (§6); none is a pure damage-race tool |
| **WP-W4** | Splash dual-types, co-op inscriptions, the combo/callback engine ties | Depth that doesn't blur the read |

Three guardrails worth restating, because a loot system is where scope dies:

1. **The whole layer is gated behind the toy.** A rich weapon hunt on top of a
   *flat* read is polish on a corpse. Prove the read first.
2. **Element constrained, inscriptions free.** §4's guardrail is the line between
   "lootable" and "Pillar-2 violation." Enforce it in the data, not just on paper.
3. **Every weapon expresses a crowd meter.** §6 is the test that keeps weapons
   from collapsing into reskinned damage.

---

## 9. Pillar-compliance self-check

- **P1 (Comedy is Combat):** weapons fill mirth / work crowd meters; nothing deals damage or injury. ✓
- **P2 (Read the Room):** element is one constrained wheel type with a guaranteed Weak; the randomizer can never make a universal answer (§4). ✓
- **P3 (Lands or Bombs):** every archetype + type has a text-free performance signature and a distinct bomb (§7). ✓
- **P4 (Co-op Chaos):** weapons are designed to want teammates (cover channels, share setups, cover wheel gaps); no competitive/PvP surface. ✓
- **P5 (Every Clown a Different Act):** archetype + type loadout differentiates *how you read and what you open*, not just numbers — and dovetails with class voice. ✓
- **Performance constraint:** zero written jokes; weapons are performance-signature loadouts, not copy. ✓

---

## 10. Open questions

1. **Does the weapon swap the auto-attack, or sit alongside it?** Recommend: swaps the auto-attack slot (cleanest Gunfire mapping); abilities stay separate.
2. **How many weapons carried at once?** One (pure Gunfire) vs two (a gag + a joke, enabling the opener→payoff rhythm solo). Recommend **two slots** so the §6 rhythm exists even solo.
3. **Is element rolled, or fixed per archetype?** Rolled gives loot depth but risks read-noise; fixed is cleaner. Recommend **rolled, single-type, guardrailed** (§4).
4. **Do inscriptions ever touch affinity?** Recommend **never** — that's the Pillar-2 firewall.
5. **Splash dual-types at all, or single-type forever?** Defer; single-type until the read is proven to survive loot.
