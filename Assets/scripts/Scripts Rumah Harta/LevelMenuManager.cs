using UnityEngine;
using UnityEngine.UI; // Wajib untuk mengatur Button UI

public class LevelMenuManager : MonoBehaviour
{
    [Header("Daftar Tombol & Gembok")]
    public Button[] tombolLevel;       // Masukkan tombol level 1, 2, 3, dst secara berurutan
    public GameObject[] iconGembok;    // Masukkan objek gambar gembok secara berurutan

    void Start()
    {
        // Mengambil data memori (Default nilai awalnya adalah 1, karena Level 1 pasti terbuka)
        int levelTerbuka = PlayerPrefs.GetInt("LevelTerbuka", 1);

        for (int i = 0; i < tombolLevel.Length; i++)
        {
            // Jika nomor urut tombol (i + 1) lebih kecil atau sama dengan level yang sudah terbuka
            if (i + 1 <= levelTerbuka)
            {
                tombolLevel[i].interactable = true; // Tombol bisa diklik
                
                // Hilangkan (sembunyikan) gambar gembok jika ada
                if (iconGembok[i] != null) 
                {
                    iconGembok[i].SetActive(false); 
                }
            }
            else
            {
                tombolLevel[i].interactable = false; // Tombol mati (tidak bisa diklik)
                
                // Munculkan gambar gembok
                if (iconGembok[i] != null) 
                {
                    iconGembok[i].SetActive(true); 
                }
            }
        }
    }
    
    // (Opsional) Tombol rahasia untuk reset level saat Anda sedang testing game
    public void ResetProgres()
    {
        PlayerPrefs.DeleteKey("LevelTerbuka");
        Debug.Log("Progres Dihapus!");
    }
}