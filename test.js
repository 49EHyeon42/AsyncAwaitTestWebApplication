import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 10,           // 10명의 동시 사용자
    duration: '30s',   // 30초 동안 실행
};

export default function () {
    http.get('http://host.docker.internal:5000/api/test');  // 변경된 부분
    sleep(1);
}