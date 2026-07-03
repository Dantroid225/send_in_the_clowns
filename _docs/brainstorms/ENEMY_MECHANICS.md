# ENEMY_MECHANICS.md — Crowd Meters & Crowd Pushback
# Game: Send in the Clowns | Folder codename: clowns
# Date: 2026-06-30 (rev 1 — EXPLORATORY, not locked)
# Authored by: game_designer_agent (combat-model scope)
# Parent docs: MIRTH_METER_SPEC.md, HUMOR_SYSTEM.md, PILLARS.md, PROJECT_SUMMARY.md
#
# DOCTRINE NOTES (inherited, non-negotiable):
#  - Pillar 1: no HP/damage/gore. Enemies are CRACKED UP, not hurt. Everything
#    below fills/empties comedic meters; nothing "injures."
#  - Performance Model: every enemy tell and every enemy "attack" is read through
#    silhouette/posture/animation/VFX/SFX — never written text.
#  - This doc OWNS enemy-side meters and enemy offense. It depends on the humor
#    side only through GetAffinity(jokeType, temperament) -> {Strong/Neutral/Weak}.
#
# SCOPE BANNER: Phase 0 is still "is the read fun?" (MIRTH_METER §6). The plain
# mirth-only enemy is the Phase 0 enemy. Everything that adds a SECOND bar or a
# reverse meter is designed here but tagged for when it earns its way in.

---

## 0. The headline

Three crowd meters, layered by how much they cost to add:

| Meter | Role (videogame analog) | Phase | Reinforces |
|---|---|---|---|
| **MIRTH** | The "HP" you fill to win | **Phase 0 (core)** | Pillars 1, 2, 3 |
| **ATTENTION** | A "shield" gating mirth | Phase 0-adjacent (cheap) | Pillar 3 (tempo) + 2 |
| **EMOTIONAL ARMOR** | "Armor" — a register lock | **Backlog** (needs Intent axis) | Pillar 2 (Intent read) |

**The constraint you set, honored as a taxonomy:** every enemy always has Mirth,
and has **at most one** of {Attention, Emotional Armor}. That yields exactly three
enemy chassis — and the second bar is **orthogonal to temperament**, so a Snob can
be Plain *or* Guarded *or* Walled. Few parts, lots of combinations.

| Chassis | Bars | Tests | Earliest |
|---|---|---|---|
| **Plain** | Mirth only | The raw read | Phase 0 |
| **Guarded** | Mirth + Attention | Read **+ tempo/sustain** | Phase 0-adjacent |
| **Walled** | Mirth + Emotional Armor | Read **+ register-switching** | Backlog |

---

## 1. MIRTH — the meter you fill to win (the core, already specced)

Unchanged from MIRTH_METER_SPEC §2–3. Fill to full → enemy is "in stitches" →
removed. Auto-attack = baseline gag; abilities = bigger typed jokes. The read
(affinity multiplier) and bombing (§3.2) are what make it *not* a reskinned HP
bar. Decay (§3.3) optional. **This doc adds nothing to Mirth itself** — it adds
*gates in front of it.*

---

## 2. ATTENTION — the "shield" (the engage gate)

> **One-line:** they aren't laughing because they aren't *watching you yet.*
> Win the room before you can fill it.

This is the cleanest second bar because it needs **no new humor axis** — it runs
entirely on the read you're already proving in Phase 0. It adds a **tempo /
sustain** dimension: you can't open with your finisher; you have to break in and
*stay* in.

### The mechanic, two framings (pick one — they're near-mirrors)

Your phrasing ("attacks won't hit mirth until attention is achieved; if fully
recharged the enemy is uninterested again") points cleanly at **Variant B**, but
both are worth a playtest:

**Variant A — Attention as a gate you RAISE (recommended if you want "earn the room").**
- Starts low (distracted, on their phone, talking to a friend).
- *Any* performing raises Attention; landing the *right* type raises it faster.
- Above a threshold → **engaged**: mirth now fills.
- Stop performing → Attention **decays**; hit zero → "uninterested again," mirth re-gated.
- *Feel:* fighting to be noticed. The pressure is "don't let them drift away."

**Variant B — Attention as a shield you BREAK (recommended — matches your "recharge" line).**
- Starts **full** = composed/aloof/"I'm above this." While the shield is up, mirth is immune.
- Performing **chips the shield**; the right type chips faster.
- Shield broken → an **open window**: mirth fills (optionally at a bonus rate).
- Stop, and the shield **recharges** back toward full → window closes → "uninterested again."
- *Feel:* cracking a facade. The pressure is "keep the window open before they re-compose."

Both produce the same valuable dynamic: **a burst-vs-sustain rhythm** and a soft
anti-spam that is *distinct from* the read without *replacing* it.

### THE GUARDRAIL — Attention must not bypass the read (Pillar 2)

Attention-break uses the **same `GetAffinity` result** as mirth fill: Strong rips
the shield, Weak barely scratches it. So a Guarded enemy is *still fundamentally a
read test* — picking right opens them faster *and* fills faster. Attention adds
tempo on top of the read; it is never a way to win without reading. If a Guarded
enemy could be cracked by spamming any loud thing regardless of type, this bar has
violated Pillar 2 and must be retuned.

### MDA trace
- **Aesthetic:** Challenge + Sensation — the anxiety of "I don't *have* them yet," then the pop of breaking in.
- **Dynamic:** you open with a *door-opener* (loud/fast performing), then switch to *payoff*; you can't tunnel one tool.
- **Mechanic:** a decaying/recharging gate meter that suppresses mirth fill until crossed, rate-scaled by affinity.

### Readable tells (Performance Model — no text)
Shield-up posture is a *silhouette*: arms crossed, looking away, phone glow on the
face, a slow disdainful sip. Breaking it has a visible **"…go on"** beat — they
turn, uncross, lean in. Re-arming is the reverse, telegraphed (they start to look
away) so the player can *read the cooldown on the room itself.*

---

## 3. EMOTIONAL ARMOR — the "armor" (the register lock)  ⚠ BACKLOG

> **One-line:** this crowd has *decided* not to laugh — a grief, a bitterness, a
> guard — and only the **right emotional register** gets through it.

Where Attention maps onto *tempo*, Emotional Armor maps onto the **Intent axis of
the humor wheel (Heart ↔ Dark)** — which is exactly why it's **backlog**: it can't
be meaningfully built until the second humor axis is online (HUMOR_SYSTEM Layer A).
Designed now so the enemy chassis is coherent; walled from Phase 0.

### The mechanic, three variants

**E2 — The Sealed Cap (recommended — most readable).**
- Mirth can fill normally, but only up to a **cap** (say 60–70%). The top of the
  bar is visibly **"walled."**
- The wall only lowers when the enemy's **keyed register** lands enough — e.g. a
  *grieving* enemy's wall yields to **Heart** (warmth/vulnerability); a *defensive
  edgelord's* wall yields to **Dark** (meet them where they live).
- Wall down → cap lifts → finish normally.
- *Feel:* "you've got them giggling, but they won't fully break until you actually
  *reach* them" — forces a deliberate **register switch** late in the fight. Very
  on-theme for the sad-clown / Heart pole.

**E1 — The Wall (flat damp).** All mirth gain reduced by a % until the keyed
register drops the wall. Simpler, but a flat multiplier is *invisible math* — bad
for Pillar 3 readability. Use only if E2 proves fiddly.

**E3 — The Regenerating Ward.** Like Attention but **register-specific**: a guard
only the keyed type lowers, and which *recharges* if you switch away. Strong, but
it couples to the combo/heckle engines (Layer B) — deepest, latest.

### Why this earns its keep
It is the mechanical reason a troupe wants **coverage of the wheel** (you can't
mono-type a Walled crowd), which is the seed of co-op role synergy
(HUMOR_SYSTEM Layer C). It converts the Intent axis from taxonomy into a thing the
player *feels.* But it must wait its turn.

### Pillar guardrail
Same as Attention: the keyed register is read off temperament via `GetAffinity`,
so a Walled enemy is a **read** (which register reaches them?), not a stat sponge.

---

## 4. ENEMIES PUSHING BACK — what "attacking" looks like

The hard constraint: **Pillar 1 forbids damage/gore.** So enemies don't *hurt*
clowns — they **upstage, heckle, fluster, and turn the room.** Their "damage" lands
on two surfaces, and crucially **only one of them is a persistent meter.**

### 4.1 The recommended model: shared Favor + transient disruption

**Surface 1 — AUDIENCE FAVOR (the shared loss condition).**
A single, **party-wide** meter — "the House," "the Room," "Favor" — for the whole
troupe, not one per clown. Heckling/booing/upstaging **drains** it; landing jokes
**refills** it. This is the cheap, on-theme answer to "what's the lose state":
- **It can bottom out — and bottoming out = you LOSE THE SET, not a death.** This
  directly serves "a wipe is quick to retry" (PROJECT_SUMMARY) and stays inside
  Pillar 1: nobody died, you just *lost the room.*
- On your "can't hit 0" instinct: a meter that literally cannot empty has no
  teeth (no loss pressure). The better expression of that instinct is **"empty =
  set over, retry,"** *not* individual death. You keep the no-lethality feel
  without removing stakes.
- *Optional tension band:* as Favor gets low, the crowd gets rowdier (heckle rate
  up) — a readable "we're losing them" spiral that's recoverable with a big bit.

**Surface 2 — PERFORMANCE DISRUPTION (per-clown, transient — NOT a health pool).**
Individual heckles don't drain a personal life bar; they **attack your timing** —
which, in a game where timing *is* the combat (Pillar 3), is the perfect non-lethal
"hit." These are short status effects, not damage:

| Enemy verb | Weapon-y analog | What it does (Pillar-1-safe) |
|---|---|---|
| **Heckle** | Single-target interrupt | Shouts you down: interrupts your current cast / spikes its bomb chance |
| **Boo / Slow-clap** | Telegraphed AoE | Drains shared Favor in a cone; dodgeable |
| **Upstage** | Aggro/zone steal | Enemy does its *own* bit — pulls Attention/Favor to itself, re-arms its own shield |
| **Phone-out / Distract** | Debuff | "Loses the thread" — scrambles your cooldowns or briefly inverts move input |
| **Tomato (cartoon)** | Dodgeable projectile | On hit: **flustered** (brief timing stumble), never injury — slapstick humiliation, not a wound |

This gives enemies real teeth while the **only persistent reverse meter is the
shared one.** That sidesteps exactly the worry the spec flagged (§5: "this doubles
the metering") — there is no second *health* bar per player, just a shared favor
bar plus transient states.

### 4.2 Richer variant (BACKLOG): per-clown "bombing" KO + bail-out

The spec's §5 model: each clown has a personal **Composure** meter; heckles fill
it; full = that clown **bombs** (downed, frozen mid-pratfall); a teammate revives
by landing a **warm (Heart) bit** on the heckler — a Fellowship beat (Pillar 4,
HUMOR_SYSTEM Layer C "bail-out is a Heart verb"). Great co-op texture, but it *is*
the second-metering-per-player cost. **Recommend: ship 4.1 first; add personal KO
only if the room-favor model proves too low-stakes in playtest.**

### 4.3 MDA trace (enemy offense)
- **Aesthetic:** Challenge + Tension ("the room can turn on us") + Fellowship (cover a flustered teammate). Never Sensation-of-being-hurt — there's no hurt.
- **Dynamic:** you can't pure-tunnel offense; you watch the room, dodge telegraphs, and trade off finishing one enemy vs. settling the crowd.
- **Mechanic:** shared favor drain + transient timing-disruption states; (backlog) personal bombing KO with Heart-verb revive.

---

## 5. How the pieces interlock (preview of WEAPON_SYSTEM.md)

These meters are **the targets weapons are designed against** — which is why the
weapon doc treats them as first-class inputs:

- **Attention** ⇒ weapons vary in *break-in power.* Loud physical **gags** crack
  shields fast; subtle **jokes** are weak openers but huge once the window's open.
  → a deliberate door-opener-then-payoff loadout rhythm.
- **Emotional Armor** ⇒ weapons carry a *register* (Heart/Dark), so Walled enemies
  *demand* specific weapons → the read matters at the loadout level, and the troupe
  wants wheel coverage (co-op).
- **Mirth decay** ⇒ sustain weapons (slapstick "SMG," rant "beam") counter it;
  burst weapons (one-liner "sniper") can't hold a room alone.
- **Enemy offense** ⇒ channelled weapons are interruptible by heckles → risk under
  pressure → a protect-the-performer co-op beat.

---

## 6. Pillar-compliance self-check

- **P1 (Comedy is Combat):** every meter is comedic; enemies upstage/heckle, never injure; loss = "lost the room," not death. ✓
- **P2 (Read the Room):** Attention-break and Armor-crack both run through `GetAffinity`, so second bars *deepen* the read, never bypass it. ✓
- **P3 (Lands or Bombs):** every meter and every enemy verb has a glance-readable, text-free tell. ✓
- **P4 (Co-op Chaos):** shared favor + (backlog) bail-out are cooperative, not competitive. ✓
- **Performance constraint:** zero written jokes; all tells and attacks are posture/animation/VFX/SFX. ✓

---

## 7. Open questions (for CONCEPT_QUESTIONNAIRE / playtest)

1. **Attention Variant A (raise) vs B (break)?** Recommend prototyping B first (matches your recharge framing).
2. **Does Attention belong in Phase 0**, or just after the plain-read is proven? (It's cheap and read-honest, but Phase 0's job is the *raw* read — don't muddy it.)
3. **Favor: pure shared (4.1) or shared + personal KO (4.2)?** Recommend 4.1 first.
4. **Does low Favor trigger a rowdiness spiral**, or stay linear? (Tension vs. frustration.)
5. **Emotional Armor keying:** one register per Walled enemy (clean), or two-register puzzles (deep, later)?
