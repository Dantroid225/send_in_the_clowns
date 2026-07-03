# Clowns.Net — RESERVED (Phase 1 slot)

Reserved for Phase 1 FishNet networking. When created, `Clowns.Net.asmdef` **references
`Clowns.Runtime`, never the reverse.** No networking code exists in Phase 0.

**Authority model is already locked (DEC-2026-06-29-B):** client-authoritative movement +
`NetworkTransform`. No server authority, no Prediction V2 / Replicate-Reconcile. Do not add an
`.asmdef` in this folder until Phase 0 passes its exit criterion.
