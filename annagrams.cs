using System;
using System.Collections.Generic;
using System.Linq;

public List<string> Annagram(String word) {
    if (string.IsNullOrEmpty(word)) {
        Console.WriteLine("The word must be at least 1 character long");
        return new List<string>();
    }
    
    var letterList = word.ToCharArray().ToList();
    
    // Creating initial list of KVP (Key Value Pairs). A dictionary is not used as it does not allow for duplicate keys which is needed for annagrams where letters are repeated
    var KVPlist = new List<KeyValuePair<string, List<char>>>()
        {
            new KeyValuePair<string, List<char>>("", letterList)
        };
        
    var processedKVPlist = ProcessKVPList(KVPlist);

    while (processedKVPlist.ElementAt(0).Value.Count > 0) {
        var newList = ProcessKVPList(processedKVPlist);
        processedKVPlist = newList;
    }
    
    // Producing final list of annagrams
    var annagrams = new List<string>();
    foreach (var entry in processedKVPlist) {
        annagrams.Add($"{entry.Key}");
    }
    var uniqueAnnagrams = annagrams.Distinct();
    Console.WriteLine($"Total annagrams: {uniqueAnnagrams.ToList().Count}");
    Console.WriteLine("Annagrams:");
    Array.ForEach(uniqueAnnagrams.ToArray(), Console.WriteLine);
    
    return uniqueAnnagrams.ToList();
}

public List<KeyValuePair<string, List<char>>> ProcessKVPList(List<KeyValuePair<string, List<char>>> KVPlist) {
    
    var newKVPlist = new List<KeyValuePair<string, List<char>>>();
    
    // Each KV entry
    foreach (var KVP in KVPlist) {
        
        var key = KVP.Key;
        var values = KVP.Value;
        
        // Each value in entry
        for (int l = 0; l < values.Count; l++) {
            newKVPlist.Add(new KeyValuePair<string, List<char>>($"{key}{values[l]}", new List<char>()));
            
            // Each value in entry again except the current
            for (int o = 0; o < values.Count; o++) {
                if (l != o) {
                    newKVPlist[newKVPlist.Count - 1].Value.Add(values[o]);
                }
            }          
        }
    }
    return newKVPlist;
}

Annagram("anna");
