# AT_Toy — seed affinity table notes

Seed defaults from `HUMOR_SYSTEM.md` §7. **Designer-owned, hot-swappable. NOT a locked decision.**

Seeded grid (`{Wit, Slapstick, Dark} × {Snob, Rowdy}`):

|           | Snob    | Rowdy  |
|-----------|---------|--------|
| Wit       | Strong  | Weak   |
| Slapstick | Weak    | Strong |
| Dark      | Neutral | Strong |

Pillar-2 expectation for this grid (validator confirms):
- best vs **Snob** = Wit
- best vs **Rowdy** = {Slapstick, Dark}
- no universal answer, no dominant type → **PASS**

Note: Dark has no Weak cell inside this 2-crowd subset — its Weak crowds (Tender/Regulars) aren't
present yet. That's expected; Dark's counterbalance (swing/risk) arrives in TB-03. Do **not** add a
"≥1 Weak per row" check until the full 5×5 is authored (noted for TB-W / Layer A).

Re-run **Clowns ▸ Validate Affinity Table** after any edit; PASS is the only gate.
