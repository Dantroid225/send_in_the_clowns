# HUMOR_SYSTEM.md — The Color Wheel of Comedy
# Game: Send in the Clowns | Folder codename: clowns
# Date: 2026-06-29 (rev 1 — first full pass)
# Authored by: game_designer_agent (humor-system scope)
# Parent docs: HUMOR_SYSTEM_BRIEF.md, MIRTH_METER_SPEC.md, PILLARS.md,
#              HUMOR_TYPE_RESEARCH.md, PROJECT_SUMMARY.md
#
# Satisfies the interface contract: GetAffinity(jokeHumorType, temperament)
#   -> { Strong, Neutral, Weak }.  Discrete at MVP; the table in §5 IS the lookup.
#
# DOCTRINE NOTE: all in-game jokes are PERFORMED GIBBERISH — no written comedy,
# ever (PROJECT_SUMMARY "Performance Model"; BRIEF §0.5). Every parent type below
# carries a PERFORMANCE SIGNATURE (§6), which is how type is actually read.
#
# SCOPE NOTE: this doc designs the FULL wheel plus the post-toy layers the owner
# asked to see (co-op, progression). MVP is a small drawn subset (§7). Backlog
# items are tagged and walled off (§8). A rich wheel does not enter Phase 0.

---

## 0. The headline: two structures, one wheel

You asked for at least two conceptual structures that bind some humor types into
synergy while splitting others into opposing halves. Here they are. They are the
spine of everything below.

- **Structure 1 — THE REGISTER SPECTRUM (Head ↔ Body).** Is the laugh in the
  *mind* (control, precision, recognition) or the *body* (impact, reflex,
  chaos)? Pure poles: **Wit** (Head) vs **Slapstick** (Body). This is the
  classic high-brow/low-brow war, and it is also Bergson's split — the mind
  locked in pattern vs. the body as a machine (HUMOR_TYPE_RESEARCH §1).

- **Structure 2 — THE INTENT SPECTRUM (Embrace ↔ Attack).** Does the laugh
  *include* (we're in this together — warmth, vulnerability, recognition) or
  *transgress* (someone or something is the target — shock, taboo, edge)? Pure
  poles: **Heart** (Embrace) vs **Dark** (Attack).

These two spectrums are roughly **orthogonal** — they measure different things —
so crossing them yields a 2×2 that every parent type and every sub-type can be
placed inside. **Absurdism** sits near the center of both: it is the wild card,
the destabiliser, the fifth point that refuses to pick a half. That is why it is
the apex of the wheel and not a pole of either axis.

```
                 ATTACK  (Intent: transgress / target)
                    │
        the Satirist│   the Shock Jock
     (Head + Sharp) │  (Body + Sharp)
                    │
  HEAD ─────────[ ABSURDISM ]───────── BODY
 (Register)         │             (Register)
                    │
     the Wry Comic  │   the Tramp
     (Head + Warm)  │  (Body + Warm)
                    │
                 EMBRACE  (Intent: include / connect)
```

**Why two structures and not one richer one:** a single axis (just high/low)
gives a tug-of-war, not a wheel — and a tug-of-war has a solved midpoint. Two
orthogonal axes give four corners that can't all be satisfied at once, which is
what forces a *read* (Pillar 2) and what gives each clown class a distinct home
(Pillar 5). One axis is a slider; two axes is a map.

---

## 1. The five parent types

Five parents, justified: three is too few to populate two axes (the corners
collapse); six-plus explodes the temperament matrix (HUMOR_TYPE_RESEARCH §6, §8).
Five lets the two opposition axes (4 poles) sit on the wheel with **Absurdism**
as the neutral pivot. Each parent is named, given a one-line identity, a clown-
tradition anchor (Whiteface / Auguste / Tramp is a real taxonomy, not invented),
and its coordinates on the two spectrums.

| Parent | One-line identity | Clown anchor | Register | Intent |
|---|---|---|---|---|
| **WIT** | The controlled mind: wordplay, dry one-liners, irony, the precise tag. | Whiteface (elegant, in charge) | **Head** (pole) | lean Sharp |
| **SLAPSTICK** | The body as a machine: pratfalls, prop chaos, escalating physical bits. | Auguste (chaotic red-nose) | **Body** (pole) | lean Embrace |
| **HEART** | We're in this together: self-deprecation, pathos, the relatable everyman. | Tramp / Pierrot (sad clown) | mid | **Embrace** (pole) |
| **DARK** | The transgressor: shock, taboo, gallows, the joke that shouldn't land. | the Wicked Harlequin | mid | **Attack** (pole) |
| **ABSURDISM** | No rules: surreal, random, non-sequitur, anti-logic. | the Fool / Zanni | mid | mid (wild) |

**Note on the seed list (HUMOR_TYPE_RESEARCH §3):** observational humor was a
seed candidate. It is deliberately *not* a parent — it is a **bridge sub-type**
that lives on the Wit↔Heart edge (clever-relatable). Folding it into the edge
instead of giving it a vertex is a scope decision: siblings merge
(HANDOFF anti-sycophancy clause). Callbacks, similarly, are a *mechanic* (§4),
not a parent.

---

## 2. Wheel geometry — adjacency (splash) and opposition

The two spectrums *generate* the pentagon. Two types are **adjacent** (they
splash, sharing sub-types) when they sit on the same half of at least one axis
and aren't poles of the other. Two types **oppose** when they sit on opposite
poles of a spectrum.

**Clockwise ring:** `WIT — ABSURDISM — DARK — SLAPSTICK — HEART — (WIT)`

**The five splash edges (synergy / shared sub-types):**

| Edge | Shared DNA (the splash zone) |
|---|---|
| **Wit ↔ Absurdism** | Intellectual surrealism — clever nonsense, the deadpan non-sequitur (Monty Python lane). |
| **Absurdism ↔ Dark** | Nightmare logic — anti-comedy, the unsettling surreal, transgressive randomness. |
| **Dark ↔ Slapstick** | Cartoon cruelty — gross-out, the painful pratfall, comic violence (Tom & Jerry lane). |
| **Slapstick ↔ Heart** | The sad clown — physical comedy *with* pathos (Chaplin's tramp, Mr. Bean's loneliness). |
| **Heart ↔ Wit** | The wry observer — relatable, clever recognition of the mundane (observational humor lives here). |

**The two marquee oppositions (the user's "opposing halves"):**

- **Register axis — WIT ⟷ SLAPSTICK.** Head vs Body. A snob recoils from a
  pie; a rowdy crowd sleeps through a pun. The cleanest, most legible read.
- **Intent axis — HEART ⟷ DARK.** Embrace vs Attack. Sincerity curdles for a
  crowd that wants edge; shock wounds a crowd that wants warmth.

**The three minor diagonals** (Wit–Dark, Absurdism–Slapstick, Absurdism–Heart)
carry *softer* tension, not full opposition. This is intentional and MTG-honest:
not every enemy pair is equally venomous. They read as Neutral-to-Weak, never as
the headline counter.

---

## 3. Sub-types & keywords (per parent)

Authored and finite — no rules-editor surface (cut-list #4). Each parent has
~3 sub-types. Sub-types near a parent's border **splash** into the adjacent
parent on the ring; sub-types near the center of the parent are its **core**.

- **WIT** — *dry one-liner* (core), *wordplay/pun* (splashes → Absurdism via
  surreal puns), *observational wit* (splashes → Heart, the wry everyman).
- **SLAPSTICK** — *pratfall* (core), *prop chaos* (splashes → Absurdism via
  wrong-prop bits), *painful gag* (splashes → Dark, the gross-out).
- **HEART** — *self-deprecation* (core), *pathos / sad-clown* (splashes →
  Slapstick, physical melancholy), *relatable observation* (splashes → Wit).
- **DARK** — *gallows / deadpan* (core), *shock / gross-out* (splashes →
  Slapstick), *anti-comedy* (splashes → Absurdism).
- **ABSURDISM** — *non-sequitur* (core), *surreal escalation* (splashes →
  Dark), *clever nonsense* (splashes → Wit).

> **Read this as the synergy map between sub-types.** A "surreal pun" is a Wit
> sub-type that scores partial credit as Absurdism; a "painful pratfall" is a
> Slapstick sub-type that scores partial as Dark. That is the sub-type-level
> synergy you asked for — adjacency isn't just parent-to-parent, it runs through
> the shared border sub-types.

---

## 4. Temperament axis (the crowd you read)

Temperaments are placed on the **same two spectrums**, so the read is "where is
this crowd on the two axes? → reach for the matching quadrant." That shared
coordinate system is what makes the read *learnable* (Pillar 3 readability).

| Temperament | Sits at | Wants | Bombs on | Readable tell (the glance) |
|---|---|---|---|---|
| **The Snob** | Head | Wit | Slapstick, Absurdism | Upright posture, formal dress, slow approving nod; flinches at "low" bits. |
| **The Rowdy** | Body | Slapstick, Dark | Wit | Loud, bouncing, restless; subtle bits sail right over them. |
| **The Tender** | Embrace | Heart | Dark | Soft body language, leans in on emotional beats, visibly winces at cruelty. |
| **The Edgelord** | Attack / chaos | Dark, Absurdism | Heart (sincerity = "cringe") | Smirk, arms crossed, knowing eye-roll; sincerity makes them sneer. |
| **The Regulars** | Embrace + grounded | Heart, Slapstick | Absurdism (too weird) | Relaxed, "I relate" laughter; blank stare at anything surreal. |

Each tell must be a *silhouette/posture/animation* read, not text (Pillar 3).
The crowd signals its quadrant; the player's skill is clocking it fast.

---

## 5. Affinity table — the `GetAffinity` lookup (THE deliverable)

Rows = joke humor type. Columns = audience temperament. Discrete at MVP. **Every
row has at least one Weak** (Pillar 2 — no universal answer). The two spectrums
are visible in the structure: the Register pair (Snob/Rowdy) mirrors Wit/Slapstick;
the Intent pair (Tender/Edgelord) mirrors Heart/Dark.

| Humor ↓ \ Crowd → | **Snob** (Head) | **Rowdy** (Body) | **Tender** (Embrace) | **Edgelord** (Attack) | **Regulars** (grounded) |
|---|---|---|---|---|---|
| **WIT** | **Strong** | Weak | Neutral | Neutral | Neutral |
| **SLAPSTICK** | Weak | **Strong** | Neutral | Neutral | Strong |
| **HEART** | Neutral | Neutral | **Strong** | **Weak** | Strong |
| **DARK** | Neutral | Strong | **Weak** | **Strong** | Weak |
| **ABSURDISM** | Weak | Neutral | Neutral | **Strong** | Weak |

Sanity checks (Pillar 2 gate, BRIEF §9):
- Wit weak→Rowdy · Slapstick weak→Snob · Heart weak→Edgelord · Dark weak→Tender/Regulars · Absurdism weak→Snob/Regulars. **Every type bombs somewhere.** ✓
- Every crowd has a clear best answer *and* a clear wrong answer. ✓
- Absurdism reads as **high-variance** (one strong, two weak, two neutral) — the
  wild card, swingy by design (matches the "random/lolz" flavor seed). ✓

> **Optional float refinement (post-MVP):** Strong ×2.0 / Neutral ×1.0 /
> Weak ×0.25, with hard-Weak (the **bold** cells) reading as a *bomb* — zero or
> negative fill + heckle pressure (MIRTH_METER §3.2). Keep discrete for Phase 0.

---

## 6. Performance signatures (no text — cadence, beat, action, VFX/SFX)

This is how type is *actually communicated* (BRIEF §0.5). Each is reused across
every ability of that type, so it does **not** multiply per-joke. Describe by
ear and eye; a blindfolded player should still name the type from cadence alone.

**WIT** — *Cadence:* clipped, flat, narrow pitch; even meter, a held SUSPENDED
beat, then a short dry downward "tag." *Animation beat:* stillness is the
delivery — one economical gesture (eyebrow raise, monocle adjust) on the tag.
*Action/prop:* a cane tap, a calling card, a sip of tea. *VFX/SFX:* crisp
rimshot, clean ding, a snap of spotlight on the land; **bomb** = crickets + one
tumbleweed.

**SLAPSTICK** — *Cadence:* rubbery, bouncy gibberish — boing vowels rising into
a splat consonant; rhythm is wind-up…wind-up…WHACK. *Animation beat:* big
telegraphed wind-up → exaggerated action → pratfall recoil; the beat lives in
the body. *Action/prop:* seltzer, oversized object, banana-peel physics.
*VFX/SFX:* slide-whistle up, anvil-clang/splat on the land; **bomb** = sad
trombone, the prop just drops.

**HEART** — *Cadence:* warm, gently wavering gibberish — a rise that softens
into a self-deprecating downturn; unhurried, "aww"-shaped vowels.
*Animation beat:* open posture, a shrug-at-self, hand-to-chest; an endearing
stumble, never a violent one. *Action/prop:* a wilted bouquet offered earnestly,
a too-big coat, a photograph. *VFX/SFX:* ukulele/accordion lilt, soft golden
glow + an "aww→warm laugh" on the land; **bomb** (Edgelord) = an awkward cough,
a cringe flinch.

**DARK** — *Cadence:* low, slow, level gibberish drifting downward; an
uncomfortable held silence before a flat deadpan delivery — no pitch
celebration. *Animation beat:* unsettling stillness → deadpan stare → one small
*wrong* gesture; the discomfort is the beat. *Action/prop:* a wilting flower, a
toy coffin, a deadpan shrug. *VFX/SFX:* discordant minor sting, a guilty
laugh-swell with a green flicker on the land; **bomb** (Tender) = record-scratch
+ gasp + the "cancelled" buzzer.

**ABSURDISM** — *Cadence:* erratic, pitch-jumping gibberish — unpredictable
rhythm, syllables that don't resolve, a tonal swerve mid-phrase; no stable
meter. *Animation beat:* setup and payoff deliberately mismatched — a pose that
doesn't fit the wind-up, "wrong" timing. *Action/prop:* a prop used for the
wrong purpose, an object from nowhere, a fourth-wall glance. *VFX/SFX:*
kazoo/theremin warble, mismatched SFX (a moo on a punch), reality-glitch
shimmer + a delayed laugh on the land; **bomb** = dead air, then one confused "?".

---

## 7. MVP playable subset (the Phase 0 output)

**Recommended: 3 types × 2 temperaments — `{Wit, Slapstick, Dark}` × `{Snob, Rowdy}`.**

This subset proves **Structure 1 (the Register read) deep, before breadth.**
Prove one axis is fun before adding the second — that is the vertical-slice
discipline (§9).

| | **Snob** | **Rowdy** |
|---|---|---|
| **Wit** | Strong | Weak |
| **Slapstick** | Weak | Strong |
| **Dark** | Neutral | Strong |

**Why this is a real decision and not "press the matching button":**
- Snob has a clear best (Wit) and a clear bomb (Slapstick) — the read is legible.
- Rowdy has *two* Strong answers (Slapstick, Dark) — but **Dark carries
  risk**: on the wrong crowd it bombs hard, and (post-toy) it can get the clown
  *cancelled*. So even when Dark is Strong, the player weighs safe-Slapstick vs
  swingy-Dark. That tension is the fun, and it's what stops the read collapsing
  into a spam (the Phase 0 failure condition, MIRTH_METER §6).

**MVP mechanic set (cheapest that makes the read matter):** flat affinity fill +
**bombing** on hard-Weak (MIRTH_METER §3.2). That single lever converts the read
from cosmetic to consequential. Everything stateful is backlog (§8).

**Phase 0 exit (binary, inherited):** *Solo, I can read Snob-vs-Rowdy, pick the
humor that lands, and the choice clearly matters.* If spamming one joke wins, the
fix is **not** more types — it is sharpening affinities or turning on the second
axis. A bigger wheel never fixes a flat read.

---

## 8. The forward look — past MVP (co-op is a priority here)

Designed on paper now, walled out of Phase 0. Ordered by when they should earn
their way in.

**Layer A — The second axis comes online.** Add `{Tender, Edgelord}` + the
**Heart** parent fully. Now both spectrums are live; the read becomes 2-D.
*Cost:* one parent, two temperaments, one new performance signature. Low-medium.

**Layer B — Two mechanical engines, one per structure.** This is where the two
conceptual structures stop being taxonomy and become *systems*:
- **Structure 1 → the Setup→Payoff combo engine.** Head/cerebral types apply a
  short-lived **primed** state (a setup); Body/visceral types **detonate** it for
  bonus fill (MIRTH_METER §3.4). Cerebral primes, visceral pays off — so the two
  halves of the Register axis want to be played *together*, not either-or. This
  is the solo skill ceiling. *Cost:* a primed-state timer. Medium.
- **Structure 2 → the Risk/Protection engine.** Embrace/warm types are safe and
  **suppress heckle pressure**; Attack/sharp types are high-variance and **build
  heckle pressure / risk the "cancelled" lockout** (seed §5, MIRTH_METER §5).
  Warm protects sharp. *Cost:* the heckle meter (a second metering surface).
  Medium. ⚠ couples to player-failure design.

**Layer C — Co-op role synergy (PRIORITY — the owner flagged co-op as core).**
Because the two structures are orthogonal, a troupe naturally wants **coverage of
the map**, and that is the co-op design, falling straight out of the geometry:
- A **Primer** clown (Head + Warm — the Wry Comic) sets up combos and holds the
  room (suppresses the team's heckle pressure).
- A **Detonator** clown (Body + Sharp — the Shock Jock) pays off setups and
  swings big *under that protection* without getting cancelled.
- **Cross-clown combos:** clown A's Wit setup → clown B's Slapstick payoff =
  a shared "bit" with bonus fill — a Fellowship beat (Pillar 4, the aesthetic in
  PROJECT_SUMMARY MDA notes).
- **Bail-out is a Heart verb:** reviving a downed teammate = landing a warm joke
  on the heckler (MIRTH_METER §5). It's thematically owned by the Embrace pole.
- **Open question to settle here:** shared mirth-per-enemy vs per-player (Summary
  Q5). Recommend **shared-per-enemy** so cross-clown combos actually matter —
  per-player pressure makes co-op parallel-play, not a troupe.

**Layer D — Roguelite progression mapped to the two structures (Gunfire-Reborn
layer).** Two skill-tree spines = the two spectrums: a **Register tree**
(Head↔Body) and an **Intent tree** (Embrace↔Attack). **Subclasses live at the
four quadrant corners** — the Satirist (Head+Sharp), the Shock Jock (Body+Sharp),
the Tramp (Body+Warm), the Wry Comic (Head+Warm). This gives the
[i]-abilities-vs-[j]-jokes split (Summary Q6) a principled geometry instead of a
flat list. **Backlog — gated entirely behind the toy passing.**

**Layer E — The sad-clown emotion bar (ICEBOX).** Re-enters via the **Heart**
parent as an alt-win (fill a separate emotion bar) *only after* the primary mirth
meter is proven. *Reason parked:* a second metering system before the first is
validated is premature (Cut-list #6).

---

## 9. Recommended process — splitting the design session (industry-standard)

You asked how to break this into structured, repeatable parts so it's built
thoroughly and consistently. This maps standard practice — **MDA backward-
tracing, vertical-slice-first, data-before-mechanics, and gated milestones** —
onto your existing phase ladder and agent roster. Each work-package is a focused
session with an **entry** and a written **exit gate**; nothing advances without
its exit criterion (your phase-gate doctrine).

| WP | Focus | Owner role | Exit gate |
|---|---|---|---|
| **WP0** | Lock the two structures + wheel geometry (this doc, §0–§3) | game_designer | Both axes defensible; every type has a weakness; 5 edges read as synergy. |
| **WP1** | Affinity table as SO **data** + MVP subset (§5, §7) | game_designer → scope | Non-degenerate grid (no solved RPS); ≥1 Weak per type; subset proves one axis. |
| **WP2** | Performance signatures + gibberish cadence (§6) | narrative_agent | Each type named by a listener **blind** (ear-only) and by silhouette (eye-only). |
| **WP3** | MVP toy build handoff — flat affinity + bombing | technical_designer → Cursor | Task Brief written; grey-box toy runs; feedback reads through performance only. |
| **GATE** | **Phase 0 playtest — "is the read fun?"** | playtest_agent | Binary: read matters vs collapses to spam. PASS unlocks WP4+. |
| **WP4** | Second axis + the two mechanical engines (Layer A–B) | game_designer | Combo + heckle prototyped; neither makes the read *less* legible. |
| **WP5** | Co-op role synergy + cross-clown combos (Layer C) | game_designer | A 2-clown fight where coverage of the map beats two soloists. |
| **WP6** | Roguelite trees on the two spectrums (Layer D) | game_designer → scope | Only opened if WP4–5 prove the engines; else stays backlog. |

Three practices worth calling out explicitly, because they're what keep a
content-multiplicative system (BRIEF §2) from spiralling:

1. **Data before mechanics.** Author the affinity grid (§5) as a ScriptableObject
   lookup and tune *that* first. Don't build a single per-type mechanic until the
   flat read is proven fun. This is the cheapest possible test of the core claim.
2. **Vertical slice before horizontal breadth.** Prove one spectrum deep (the MVP
   subset, §7) before populating the second. Breadth is the trap; depth is the
   proof.
3. **System vs content separation.** The *wheel* (this doc) is system design; the
   *populated sub-types and their cadences* are content authoring (WP2). Keep the
   two sessions distinct so balancing the geometry never waits on art.

---

## 10. Icebox / backlog register (parked, with reasons)

| Item | Status | One-line reason |
|---|---|---|
| Sad-clown **emotion bar** (alt-defeat) | ICEBOX | Second metering system before the first is proven (Cut-list #6). |
| **"Cancelled"** backfire lockout state | BACKLOG | Adds a state machine; MVP gets the cheap version (bomb = zero/negative fill) without the FSM. |
| **Callbacks** (mirth-over-time) | BACKLOG | Needs a primed/marked state; it's the combo engine (Layer B), not a flat-read mechanic. |
| **Self-deprecating self-cost** trade | BACKLOG | Couples to the heckle meter; arrives with Layer B. |
| **Roguelite trees / subclasses** | BACKLOG | Gated behind the toy; geometry is designed (Layer D) but unbuilt. |
| **Float multipliers** for affinity | BACKLOG | Discrete {Strong/Neutral/Weak} is enough to prove the read; numbers are a tuning refinement. |
| Parents beyond 5 / sub-type sprawl | CUT-on-sight | Siblings merge; >5 parents breaks the temperament matrix (RESEARCH §8). |

---

## 11. Pillar-compliance self-check

- **Pillar 1 (Comedy is Combat):** fill, not damage; defeat = "in stitches." ✓
- **Pillar 2 (Read the Room):** every type bombs somewhere (§5); no universal
  answer; the two-axis read is the central decision. ✓
- **Pillar 3 (Lands or Bombs):** every type has a distinct performance signature
  and a distinct bomb (§6); temperaments have glance-readable tells (§4). ✓
- **Pillar 4 (Co-op Chaos):** co-op synergy designed as map-coverage, not
  competition (Layer C). ✓
- **Pillar 5 (Every Clown a Different Act):** the four quadrant corners are four
  genuinely different reads, not stat reskins (§0, Layer D). ✓
- **Performance constraint:** zero written jokes anywhere in this doc. ✓
