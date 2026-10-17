# Remove Medieval Stuff - GitHub Copilot Instructions

## Overview

**Mod Name:** Remove Medieval Stuff  
**Author:** Mlie  
**PackageId:** Mlie.RemoveMedievalStuff  
**Dependencies:** brrainz.harmony

**Mod Description:**  
"Remove Medieval Stuff" is a RimWorld mod that allows players to selectively remove items, research, factions, and pawnkinds from the medieval era and above. This mod is inspired and based heavily on "Lord of the Rims - The Third Age". It provides users with a streamlined experience if they wish to limit their gameplay to pre-medieval technology, enhancing the thematic coherency for certain gameplay scenarios or narrative structures.

## Key Features and Systems

- **Selective Removal:** The mod offers options to remove all items, research, factions, and pawnkinds from the medieval era and above, tailoring the game's content to a specific technological theme.
- **User Control:** Players can customize their experience by selecting what aspects of medieval (and greater) content they want to exclude.
  
## Coding Patterns and Conventions

1. **Namespace and Type Organization:**
   - Each functionality adheres to a specific namespace pattern based on its role, facilitating easy access and modification.
   - Types and members are purposefully named for clarity.

2. **Consistency:**
   - Consistent use of prefixes in Harmony patches to denote different patches (e.g., `Prefix` for method prefixing).

3. **Descriptive Naming:**
   - Variables, methods, and class names are descriptive, indicating their purpose and function in the code.

## XML Integration

- Currently, there are no XML files included in the mod, emphasizing a code-centric approach for removing content.
- Future integrations may include XML configurations to offer more flexibility in terms of user configuration.

## Harmony Patching

- The mod utilizes Harmony, a library for patching the game code without modifying the original game files, providing a non-destructive way to implement changes.
- Each Harmony patch is located within its own C# file where:
  - **Prefix Methods:** These methods are prefixed in the code to override or adjust original game functionality before execution of the original method.
  
### Example Harmony Patches:

1. **BackCompatibility_FactionManagerPostLoadInit**  
   - Adjustments to the post-load initialization for removing medieval faction compatibilities.

2. **ThingSetMakerUtility_CanGenerate**  
   - Filtering of items generated during gameplay to exclude those from medieval tech level and above.

3. **ThingSetMaker_Generate**  
   - Modifying item generation to align with the removal criteria of the mod.

4. **FactionManager_FirstFactionOfDef**  
   - Ensures factions above the medieval tech level are not generated at game start.

## Suggestions for Copilot

1. **Pattern Recognition:**  
   Have Copilot recognize the role of Harmony patches and suggest consistent prefix and postfix method templates for alterations in game logic.

2. **Class and Member Generation:**  
   Assist in generating new classes and members with a guideline adherence to maintain structure uniformity.

3. **Stub Integration Points:**  
   Suggest inline comments or "TODO" stubs where further expansion can be made (e.g., XML configuration integration).

4. **Error Handling:**  
   Provide suggested error handling patterns to gracefully handle exceptions that may arise from missing or incompatible content removal.

5. **Documentation and Comments:**  
   Encourage the insertion of useful comments and summaries to improve code readability and maintainability for future contributions or modifications.

---

This .github/copilot-instructions.md file serves as a centralized guide for developing and extending the Remove Medieval Stuff mod. It provides context and coding standards that contributors should follow for consistency and efficiency.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

