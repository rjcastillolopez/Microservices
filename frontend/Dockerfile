# Stage 0, based on Node.js
FROM node:latest as node
WORKDIR /usr/src/app
COPY ./ /usr/src/app
RUN npm install
RUN npm run build -- --configuration production

# Stage 1, based on Nginx
FROM nginx:alpine
COPY --from=node /usr/src/app/dist/app-scores /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]