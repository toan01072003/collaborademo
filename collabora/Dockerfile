# Không ghim tag để tránh not found
FROM collabora/code

# Railway terminate TLS ngoài edge → chạy HTTP nội bộ
ENV extra_params=--o:ssl.enable=false

# TẠM nới lỏng để test; sau khi chạy OK thì set đúng ở Variables trên Railway
ENV domain=.+

# Port service
EXPOSE 9980

# Không cần COPY script, không cần chmod, dùng entrypoint mặc định của image
