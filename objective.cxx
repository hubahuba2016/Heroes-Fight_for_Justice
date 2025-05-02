#include <iostream>
#include <map>
#include <iomanip>
#include <string>
#include <algorithm>

using namespace std;

// Struktur untuk menyimpan data unsur
struct Element {
    string symbol;
    int atomic_number;
    double atomic_mass;
};

// Peta unsur berdasarkan nama (huruf kecil)
const map<string, Element> elements = {
    // Non-logam
    {"hydrogen", {"H", 1, 1.008}},
    {"helium", {"He", 2, 4.0026}},
    {"carbon", {"C", 6, 12.011}},
    {"nitrogen", {"N", 7, 14.007}},
    {"oxygen", {"O", 8, 15.999}},
    {"sodium", {"Na", 11, 22.990}},
    {"chlorine", {"Cl", 17, 35.45}},

    // Logam
    {"iron", {"Fe", 26, 55.845}},
    {"copper", {"Cu", 29, 63.546}},
    {"gold", {"Au", 79, 196.9665}},
    {"silver", {"Ag", 47, 107.8682}},
    {"aluminum", {"Al", 13, 26.9815}},

    // Gas mulia
    {"helium", {"He", 2, 4.0026}},
    {"neon", {"Ne", 10, 20.1797}},
    {"argon", {"Ar", 18, 39.948}},
    {"krypton", {"Kr", 36, 83.798}},
    {"xenon", {"Xe", 54, 131.293}},
    {"radon", {"Rn", 86, 222.018}}
};

// Fungsi konversi string ke huruf kecil
string toLower(string str) {
    transform(str.begin(), str.end(), str.begin(), ::tolower);
    return str;
}

// Menampilkan daftar unsur
void listAvailableElements() {
    cout << "Available Elements:\n";
    for (const auto& pair : elements) {
        cout << "  - " << pair.first << " (" << pair.second.symbol << ")\n";
    }
    cout << endl;
}

// Menampilkan detail dari unsur
void displayElement(string name) {
    string lowerName = toLower(name);

    if (elements.count(lowerName)) {
        const Element& el = elements.at(lowerName);
        cout << "\nElement Details:\n";
        cout << "  Name          : " << name << endl;
        cout << "  Symbol        : " << el.symbol << endl;
        cout << "  Atomic Number : " << el.atomic_number << endl;
        cout << "  Atomic Mass   : " << fixed << setprecision(4) << el.atomic_mass << endl;
    } else {
        cout << "\nElement '" << name << "' not found in the database.\n";
    }
}

// Fungsi utama
int main() {
    listAvailableElements();

    // Menambahkan contoh input yang valid
    cout << "Example valid inputs: 'oxygen', 'gold', 'neon'\n";
    cout << "Note: Please type the element name exactly as shown (case-insensitive).\n\n";

    string input;
    cout << "Enter the element name from the list above: ";
    getline(cin, input);

    displayElement(input);

    return 0;
}