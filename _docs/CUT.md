# CUT.md — Send in the Clowns
# Purpose: Out-of-scope items that are CUT — either permanently, or because a pillar
#          excludes them. Each entry names the pillar/reason that cuts it.
# Created: 2026-06-30 | Last Modified: 2026-06-30
# Source: split out of ONE_PAGE_GDD.md "Out of Scope From Day 1" (single-source rule —
#         the GDD now points here instead of duplicating).
# Distinction: CUT = excluded by a pillar or permanently out. BACKLOG = parked-not-killed
#              with a promotion condition. ICEBOX = parked with a review-or-kill default.

---

## C-1. PvP / competitive play
**Cut by:** Pillar 4 (Co-op Chaos, Not Competition). This is co-op PvE.
**Permanent:** Yes. PvP would invert the entire design and reintroduce balance/anti-cheat cost.

## C-2. MOBA economy — lanes, creeps-as-economy, towers, jungle, gold, shops, leveling/XP
**Cut by:** Pillar 1 + scope discipline. The toy borrows Battlerite arena feel, not MOBA economy.
**Permanent:** Yes for the economy layer. (LoL contributes camera + right-click-move controls ONLY.)

## C-3. Matchmaking, ranked, accounts, dedicated servers, anti-cheat
**Cut by:** Pillar 4. Friends host/join directly; cheating is a non-problem.
**Permanent:** Yes at MVP and as designed. Revisit ONLY if a future locked decision reintroduces
persistence/accounts — which would also require re-adding a backend (currently cut, see scaffolding §1).

## C-4. Deep humor-rules editor / player-facing rules builder
**Cut by:** Scope discipline. The playable humor read is a FIXED SMALL SUBSET of the color wheel,
not a builder. The full wheel lives in the humor-system agent's design space, not as a shipped editor.
**Permanent:** The editor is cut. (The wheel itself is design input — see HUMOR_SYSTEM_BRIEF.md.)

## C-5. Minimap, spectator mode, reconnect
**Cut by:** Scope discipline. Single-screen arena, 2-player MVP — none of these are needed.
**Permanent:** At MVP. Reconsider only if the eventual roguelite tour (BACKLOG) changes the frame.

## C-6. Written / scripted jokes, real comedy text, localized joke content
**Cut by:** DEC-2026-06-29-C (Gibberish Performance constraint) + Pillars 1/3/5.
**PERMANENT — NOT BACKLOG.** All in-game humor is performed gibberish (cadence/animation/action/
VFX/SFX). There is no joke-writing pipeline to scope, now or ever. Localization of joke dialogue is
moot for the same reason. This is the single most load-bearing cut in the project.
