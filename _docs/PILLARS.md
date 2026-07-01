# PILLARS.md — Send in the Clowns
# Folder codename: clowns
# Locked: 2026-06-29 (rev 1)
# Source: PROJECT_SUMMARY.md (one-page GDD)
#
# Pillars are the gate for every feature. A proposed feature must serve at
# least one pillar or it routes to CUT.md. Each pillar's VIOLATION EXAMPLE is
# the concrete thing the scope_agent tests new features against.

---

## Pillar 1: Comedy Is Combat

Your weapons are jokes. You win a fight by breaking the room — pushing an
enemy past their composure into helpless laughter — not by drawing blood.
The aesthetic is the joy of a bit landing, not the satisfaction of a kill.

**Violation example:** A literal HP/damage number, a blood/gore effect, or a
"finishing blow" framed as lethal violence. If a feature reads as *hurting*
rather than *cracking up*, it violates this pillar.

---

## Pillar 2: Read the Room

The central decision is choosing the humor that fits the audience. Each enemy
has a temperament; each joke has a humor type; the match between them is
strong, weak, or neutral. The fight is a live reading exercise, not a
damage race.

**Violation example:** A humor type that's strong against everything; a
"best joke" that's always correct; or an enemy with no temperament so matchup
doesn't matter. Any of these erases the read and the pillar with it.

---

## Pillar 3: The Bit Lands or Bombs

Timing and feedback make a joke *hit*. Casts land with immediate, readable
comedic payoff — a visible spike on the mirth meter, a sound, a reaction. A
mistimed or mismatched joke visibly *bombs*. The player always knows whether
the bit worked. **All of this is communicated through performance — vocal
cadence, animation timing, action/prop use, VFX/SFX — never through written
text**, because no clown or enemy ever speaks real, scripted jokes (see
`PROJECT_SUMMARY.md`, "Performance Model").

**Violation example:** A feedback-less ability; a meter that creeps up with no
"pop"; sluggish pathing or input that swallows the timing; an effect the
player can't read in the moment; **any joke that relies on the player reading
written punchline text to understand it landed.**

---

## Pillar 4: Co-op Chaos, Not Competition

It's you and your friends versus the crowd. Because no one competes, cheating
and competitive balance simply don't exist as problems — which keeps the
netcode cheap and the vibe loose. Jank is acceptable; fun is not negotiable.

**Violation example:** PvP, ranked play, matchmaking, accounts, dedicated
servers, or any engineering spent on anti-cheat / server authority. All of it
is out of scope by this pillar.

---

## Pillar 5: Every Clown's a Different Act

Each clown class is a distinct comedic voice — a tramp, a Pierrot, a jester,
an Auguste — tied to humor archetypes, not a stat reskin. Picking a class
changes *how you read the room* and *what lands*, not just your numbers.

**Violation example:** Two classes that differ only in stat values or a
palette swap; a class whose kit doesn't change which temperaments you're
strong against. If swapping clowns doesn't change the read, the roster is
decoration, not design.

---

## Standing Constraint: Gibberish Performance (load-bearing on Pillars 1, 3, 5)

All in-game "jokes" are **performed in videogame gibberish** (Simlish /
Animal Crossing / Undertale "bark text" style) — never real, written, or
scripted comedy. Humor type must be legible entirely from **cadence,
animation timing, action/prop use, and VFX/SFX**, not from text content. See
`PROJECT_SUMMARY.md`, "Performance Model — Gibberish, Not Real Jokes" for the
full rationale (it is a scope-positive finding: no joke-writing pipeline, no
localization burden, no copyright risk).

**Violation example:** Any feature requiring the player to read a written
punchline, a real joke displayed as text/subtitle as the PRIMARY comedic
payload, or any system that depends on actual comedic writing quality rather
than performance design.

---

## Candidate Future Pillar (BACKLOG — NOT LOCKED)

### "The Tour Is the Run"
Escalating venues and crowds (open mic → rodeo → theatre, with a boss act)
give the eventual roguelite its shape and stakes.

**Status:** Parked deliberately. Ranked last on the protect-list; first to cut.
**Promotion condition:** Only after the Phase 0 combat toy proves fun. Do not
let this pillar's absence be treated as a gap — the toy does not need it.

---

## Pillar-Gate Quick Reference (for scope_agent)

| If a proposed feature… | …it likely | Because |
|---|---|---|
| frames combat as damage/lethality | **CUT** | Violates Pillar 1 |
| makes one humor type universally best | **CUT** | Violates Pillar 2 |
| has no readable feedback | **rework or CUT** | Violates Pillar 3 |
| adds PvP / ranked / anti-cheat | **CUT** | Violates Pillar 4 |
| adds a class that's a stat reskin | **CUT / merge** | Violates Pillar 5 |
| adds venues / runs / bosses / meta progression | **BACKLOG** | Future pillar, not launched |
