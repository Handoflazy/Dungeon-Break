using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class Bow : Collidable
{
    // Start is called before the first frame update
    public GameObject player;
    //public GhostController ghostController;

    public GameObject arrowPrefab; // Prefab của đạn
    public GameObject arrowPrefab1;
    public GameObject arrowPrefab2; // Prefab của đạn
    public GameObject arrowPrefab3;
    public Transform firePoint; // Vị trí bắn đạn

    public float arrowSpeed = 15f; // Tốc độ đạn
    public float arrowSpeed2 = 3f;
    public float fireRate = 2f; // Tốc độ bắn (đơn vị: đạn/giây)
    public float cooldownE = 3f;
    public float cooldownQ = 2f;
    public float cooldownSpace = 3f;

    private float timeSinceLastShot = 0f;
    private float timeSinceE = 0f;
    private float timeSinceQ = 0f;
    private float timeSinceSpace = 0f;

    //public bool knockBack = false;
    public float knockbackForce = 2f; 

    public int numberOfBullets = 1;
    private Animator anim;

    
    //private bool bulletTargeting ;
    private Rigidbody2D playerRb;
    private TrailRenderer trailRendererPlayer;
    public float backstepDistance = 5f; // Khoảng cách backstep
    //public float backstepSpeed = 10f; // Tốc độ di chuyển khi backstep
    //private bool isBackstepping = false; // Biến để kiểm tra xem có đang backstep không

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        
        /*ghostController = GetComponent<GhostController>();
        ghostController.enabled = false;*/
        //Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        timeSinceE += Time.deltaTime;
        timeSinceQ += Time.deltaTime;
        timeSinceSpace += Time.deltaTime;

        /*if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = - transform.localScale;
        }*/

        /*// Xác định hướng của chuột
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = (mousePosition - transform.position).normalized;

        // Xoay Player để nhìn theo hướng của chuột
        float angle2 = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle2));*/

        // Kiểm tra giá trị của các trục di chuyển
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Nếu cả hai giá trị đều bằng 0, có nghĩa là người chơi không nhập nút di chuyển
        if (horizontalInput == 0 && verticalInput == 0)
        {

            // Bắn đạn khi nhấn nút Space và đủ thời gian giãn cách
            if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= 1f / fireRate)
            {
                Shoot();
            }
            if ((Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(1)) && timeSinceQ >= cooldownQ)
            {
                BackStepSkill();
            }
            if (Input.GetKeyDown(KeyCode.E) && timeSinceE >= cooldownE)
            {
                MultiArrowSkill();
            }
            if (Input.GetKeyDown(KeyCode.Space) && timeSinceSpace >= cooldownSpace)
            {
                KnockBackSkill();
            }
        }

        TrailRenderer trailRendererPlayer = player.GetComponent<TrailRenderer>();
        if (timeSinceQ >= 0.5f) { trailRendererPlayer.enabled = false; }
    }


    void Shoot()
    {
        anim.SetTrigger("shoot");
        // Tạo và bắn đạn
        GameObject bullet = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

        // Xác định hướng bắn của đạn (theo hướng nhìn của Player)
        Vector3 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Tính toán góc quay để đạn bay theo hướng đã xác định
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Xoay đạn theo góc đã tính
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Bắn đạn bằng cách thiết lập vận tốc cho đạn
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bullet.transform.right * arrowSpeed;

        // Lùi lại Player sau khi bắn
        //transform.Translate(Vector3.back * recoilDistance);

        // Đặt lại thời gian từ lúc bắn
        timeSinceLastShot = 0f;

        // Hủy đạn sau x giây
        Destroy(bullet, 3f);
    }
    void MultiArrowSkill()
    {
        anim.SetTrigger("shoot");
        // Góc tán xạ tối đa (ở hai bên của hướng nhìn)
        float maxScatterAngle = (numberOfBullets - 1) * 10;

        // Tính góc giữa các viên đạn
        float angleBetweenBullets = (2 * maxScatterAngle) / numberOfBullets;

        // Góc tán xạ ban đầu
        float initialScatterAngle = -maxScatterAngle;

        // Khoảng cách giữa các viên đạn
        float bulletSpacing = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            // Tạo và bắn đạn
            GameObject bullet = Instantiate(arrowPrefab1, firePoint.position, Quaternion.identity);

            // Xác định hướng bắn của đạn (theo hướng nhìn của Player)
            Vector3 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            // Tính toán góc quay để đạn bay theo hướng đã xác định, với sự chệch góc
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + initialScatterAngle;

            // Xoay đạn theo góc đã tính
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Bắn đạn bằng cách thiết lập vận tốc cho đạn
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.right * arrowSpeed2;

            // Đặt lại thời gian từ lúc bắn
            timeSinceLastShot = 0f;

            // Tăng góc tán xạ cho viên đạn tiếp theo
            initialScatterAngle += angleBetweenBullets;

            // Điều chỉnh vị trí của viên đạn để tránh va chạm
            bullet.transform.position += bullet.transform.right * (bulletSpacing);

            timeSinceE = 0f;
            // Hủy đạn sau x giây
            Destroy(bullet, 3f);
        }
    }
  
    void BackStepSkill()
    {
        //ghostController.enabled = true;
        anim.SetTrigger("shoot");
        // Lấy hướng bắn của đạn (theo hướng nhìn của Player)
        Vector3 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Tạo và bắn đạn
        GameObject bullet = Instantiate(arrowPrefab2, firePoint.position, Quaternion.identity);


        // Tính toán góc quay để đạn bay theo hướng đã xác định
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Xoay đạn theo góc đã tính
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Bắn đạn bằng cách thiết lập vận tốc cho đạn
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bullet.transform.right * arrowSpeed2;

        // Hủy mũi tên sau x giây
        Destroy(bullet, 10f);

        /*// Xác định hướng lùi lại của Player (ngược với hướng bắn của đạn)
        Vector3 backstepDirection = -lookDirection;

        // Tính lực đẩy dựa trên hướng lùi lại và lực của backstep
        Vector2 backstepForce = backstepDirection * backstepDistance;*/

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        // Áp dụng lực đẩy lên Player
        playerRb.AddForce(-bullet.transform.right*backstepDistance, ForceMode2D.Impulse);

        timeSinceQ = 0f;

        TrailRenderer trailRendererPlayer = player.GetComponent<TrailRenderer>();
        trailRendererPlayer.enabled = true;
        
        
    }

    void KnockBackSkill()
    {
        anim.SetTrigger("shoot");
        //knockBack = true;

        // Tạo và bắn đạn
        GameObject bullet = Instantiate(arrowPrefab3, firePoint.position, Quaternion.identity);

        // Xác định hướng bắn của đạn (theo hướng nhìn của Player)
        Vector3 lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        // Tính toán góc quay để đạn bay theo hướng đã xác định
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Xoay đạn theo góc đã tính
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Bắn đạn bằng cách thiết lập vận tốc cho đạn
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bullet.transform.right * arrowSpeed;

        // Lùi lại Player sau khi bắn
        //transform.Translate(Vector3.back * recoilDistance);

        // Đặt lại thời gian từ lúc bắn
        timeSinceSpace = 0f;

        // Hủy đạn sau x giây
        Destroy(bullet, 3f);
        

    }

}



