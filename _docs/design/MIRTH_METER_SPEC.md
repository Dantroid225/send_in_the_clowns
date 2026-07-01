# MIRTH_METER_SPEC.md — Core Combat Model (THE TOY)
# Game: Send in the Clowns
# Folder codename: clowns
# Date: 2026-06-29 (rev 1)
# Authored by: Deep Game Designer / game_designer_agent (combat model)
# Owns the interface that the SEPARATE humor-triangle agent's HUMOR_TRIANGLE.md must satisfy.
#
# This is the highest-priority design doc: it specifies the protected feature
# (humor-meter combat + the read). It is a DESIGN spec, not code. Implementation
# is handed to Cursor via Task Brief.

---

## 1. Purpose & The One Question

Replace HP-and-damage with **mirth-and-jokes**. The make-or-break design
question this doc exists to answer in Phase 0:

> **Is filling a meter mechanically different from depleting an HP bar — and is
> the humor-type READ a genuinely fun decision?**

A reskin is not enough. If "joke" is just "damage" with a clown hat, the toy
fails. The mechanics below are candidate sources of *real* difference. Phase 0
prototypes them to find which (if any) make the read fun. **Do not ship all of
them — prove the minimum that's fun.**

---

## 2. The Mirth Meter (the HP replacement)

- Each enemy has a **Mirth meter** (working name; alts: Hysteria, Giggle Gauge,
  "The Bit"). It starts empty.
- Jokes/gags **increase** mirth. At **full**, the enemy is **defeated** — they're
  "**in stitches**" (working term; alts: "laughing themselves silly," "corpsing,"
  "rolling") and removed from the fight.
- **Auto-attack** = a low-value baseline gag (the always-available verb).
- **Abilities** = bigger, type-flavored jokes on cooldown (3 per clown, trim to
  1–2 at the first combat milestone).

This much alone is reskinned HP. The next section is what makes it a toy.

---

## 3. Four Candidate "Fill ≠ HP" Mechanics (prototype, don't assume)

Each is a lever that could make the meter behave unlike an HP bar. Phase 0
tests them roughly in this priority order:

### 3.1 The Read (Pillar 2) — HIGHEST PRIORITY, likely part of the toy
Every enemy has a **temperament**. Every joke has a **humor type**. An
**affinity multiplier** scales how much mirth a joke adds:
- **Strong** match → large fill ("super-effective" — the bit kills).
- **Neutral** → baseline fill.
- **Weak** match → tiny fill, or it *bombs* (see 3.2).

This is the candidate core of the fun. If even a minimal **2–3 type** read
makes fights interesting, the read is part of the toy and Phase 0 includes it.

### 3.2 Bombing / Overflow (anti-spam)
Landing the *wrong* humor type — or hammering one type a resistant crowd has
"heard before" — causes the joke to **bomb**: zero or negative fill, and/or it
builds **heckle pressure** on the player (see §5). This punishes spam and
rewards variety + reading. Distinct from HP: you can make the situation
*worse* by attacking.

### 3.3 Decay / Cooling (tempo)
Mirth **drains** over time when you stop landing jokes — the room cools. This
forces sustained pressure and rhythm, unlike HP which never refills for free.
Tuning knob: decay rate. (Risk: too fast = frustrating; too slow = pointless.
A Phase 0 dial, not a shipped certainty.)

### 3.4 Setup → Punchline Combos (skill expression)
Some gags **set up** (apply a short-lived "primed" state); others **pay off**
(bonus fill, or guaranteed strong, if a setup is active). Two-step comedic
structure → a skill ceiling that HP-chipping doesn't have. Keep optional;
add only if 3.1–3.2 aren't carrying the fun alone.

---

## 4. The Triangle Interface — CONTRACT for the separate agent

The separate humor-triangle agent owns `HUMOR_TRIANGLE.md` (the type list and
the strong/weak relationships). To keep the two docs decoupled, the combat
model only depends on this **contract** — not on the triangle's internals:

```
GetAffinity(jokeHumorType, audienceTemperament) -> AffinityResult
  AffinityResult ∈ { Strong, Neutral, Weak }     // MVP: discrete
  (optional later) -> float multiplier            // e.g. 2.0 / 1.0 / 0.25
```

- The triangle agent may change the type list, add types, or rebalance freely,
  **as long as it exposes `GetAffinity`**. The mirth meter reads only the result.
- **MVP constraint (scope):** discrete `{Strong, Neutral, Weak}` and a **small
  fixed set** of humor types. No rules editor, no per-enemy custom matchups
  beyond temperament. (Pillar 2 + cut list.)
- Implementation note for the eventual Task Brief: humor types and temperaments
  are **ScriptableObjects**; `GetAffinity` is a lookup, inspector-tunable.

---

## 5. Player Failure (the reverse meter) — design question, not locked

For the player to lose, enemies need a way to push back. Candidate, symmetric
and thematic:
- Enemies **heckle** — a reverse pressure that fills the player's
  **Composure / "Bombing" meter**. Full = the clown **bombs** (downed).
- Co-op: a downed clown can be "**bailed out**" by a teammate landing a joke on
  the heckler (a fellowship beat — Pillar 4).

**Flagged as open:** this doubles the metering. Phase 0 can start with a simpler
loss (clowns have a small classic health pool, OR a timer/wave-survival loss)
and only add heckle-pressure if the toy wants it. Don't over-build the loss
condition before the *win* condition is proven fun.

---

## 6. Phase 0 Minimal Version (the thing to actually build first)

Solo, no networking, grey-box. The smallest build that answers "is the read
the fun?":

- [ ] One clown, click-to-move, auto-attack + 1–2 ability "jokes" (SO-based).
- [ ] One enemy with a temperament, displaying a mirth meter.
- [ ] A **minimal 2–3 type** read via `GetAffinity` (Strong/Neutral/Weak).
- [ ] Readable feedback on every joke: meter spike + a "lands / bombs" pop (Pillar 3). **All jokes are performed in videogame gibberish (no real written text) — feedback must read entirely through cadence, animation, and VFX/SFX; see `PROJECT_SUMMARY.md` "Performance Model."**
- [ ] **At least one** of the distinguishing mechanics from §3.2–3.4 (start with
      bombing, §3.2 — it's the cheapest way to make the read *matter*).
- [ ] A trivial spawner / a few enemies to fight in sequence.

**Phase 0 exit (binary):** *Solo, I can read an enemy's temperament, choose the
humor that lands, and the choice clearly matters — there is a real, fun gap
between "read and pick right" and "spam one joke." If spamming one joke wins, or
the read feels like busywork → FAIL (pivot the core).*

---

## 7. Open Questions (feed CONCEPT_QUESTIONNAIRE.md §2)

1. Which of §3.1–3.4 carry the fun? (Phase 0 answers empirically.)
2. Discrete `{Strong/Neutral/Weak}` or numeric multipliers at MVP?
3. Does mirth decay, or is it monotonic? (Tempo vs. simplicity.)
4. Player loss: heckle-meter, classic health, or wave-survival timer?
5. Defeat term + meter name (narrative_agent, low priority).
