Feature: DimensionStructureTree endpoint - Add Root DimensionStructure method
  
  As a Data Owner and Data Curator
  I need to be able to build DimensionStructure trees
  Which starts with adding root DimensionStructure to a SourceFormat
  So that, I need a functionality which providing it.
  
  Scenario: Adding existing root DimensionStructure to a SourceFormat
    
    Given there is a saved SourceFormat object
    And there is a saved DimensionStructure object
    
    When DimensionStructure is added to SourceFormat as root DimensionStructure
    And SourceFormat is requested with its root DimensionStructure
    
    Then DimensionStructure is root DimensionStructure of SourceFormat
    
    
    Scenario: Adding brand new root DimensionStructure to a SourceFormat

      Given there is a saved SourceFormat object
      And there is a saved DimensionStructure object

      When DimensionStructure is added to SourceFormat as root DimensionStructure
      And SourceFormat is requested with its root DimensionStructure

      Then DimensionStructure is root DimensionStructure of SourceFormat